import * as React from 'react';
import { useSelector, useDispatch } from "react-redux";
import { useState, useEffect } from "react";
import FileService from "../../services/FileService";
import { InputLabel, FormControl, Select, MenuItem, Stack } from '@mui/material';
import { enqueueSnackbar } from 'notistack';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import Grid from '@mui/material/Grid';
import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import CardMedia from '@mui/material/CardMedia';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import * as XLSX from 'xlsx';
import dayjs from 'dayjs';
import { getCalendarEvents } from '../../store/actions/calendar-actions';
import { getCalendarUsers } from '../../store/actions/calendar-actions';
import CalendarTable from './calendar-table';

const CalendarManage = () => {

  const dispatch = useDispatch();
  // const [eventDate, setEventDate] = useState();
  const [eventType, setEventType] = useState('');
  const [eventMonth, setEventMonth] = useState('');
  const { calendars } = useSelector(state => state.calendar);
  const currentCalendar = calendars.find(calendar => calendar.active);
  const currentYear = new Date().getFullYear();
  const [isEvents, setIsEvents] = useState(true)
  // const [buttonValue,setButtonValue]=useState('עבור לרשימת המשתמשים')
  const [usersRows, setUsersRows] = useState(currentCalendar.users.map(user => {
    const image = FileService.getImageUrl(user.siteUserId);
    return createData(user.id, user.firstName + " " + user.lastName, user.tz, user.phoneNumber, user.email, <CardMedia sx={{ height: '10vh' }} image={image} title="green iguana"></CardMedia>)
  }));
  const [eventRows, setEventRows] = useState(currentCalendar.events.map(event => {
    const image = FileService.getImageUrl(currentCalendar.users.find(user => user.id === event.userId).siteUserId);
    const dateParts = event.gregorianDate.split('-');
    const formattedDate = `${dateParts[2]}/${dateParts[1]}/${currentYear}`;
    return createData(event.id, event.eventOwnerName, event.eventType, formattedDate, `${!(event.oneTimeEvent) && currentYear - dateParts[0] > 0 ? currentYear - dateParts[0] : ""}`, <CardMedia sx={{ height: '10vh' }} image={image} title="green iguana"></CardMedia>
    )
  }));

  useEffect(() => {
    dispatch(getCalendarUsers(currentCalendar.id));
    dispatch(getCalendarEvents(currentCalendar.id));
  }, [])

  const exportToExcel = () => {
    const worksheet = XLSX.utils.json_to_sheet(isEvents ? eventRows : usersRows);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, 'Sheet1');
    XLSX.writeFile(workbook, 'data.xlsx');
  }

  const handleSubmit = async (event) => {
    event.preventDefault();
    const formData = new FormData(event.target)
    const data = Object.fromEntries(formData.entries())
    const filteredData = [];
    try {
      currentCalendar.events.filter(event => {
        const userForImage = currentCalendar.users.find(user => user.id === event.userId)
        const image = FileService.getImageUrl(userForImage.id);
        const dateParts = event.gregorianDate.split('-');
        const formattedDate = `${dateParts[2]}/${dateParts[1]}/${currentYear}`;
        const typeMatch = eventType === "" || data.type === event.eventType || (data.type == "other" && event.eventType !== "יומולדת" && event.eventType !== "יום השנה" && event.eventType !== "יום נישואין")
        //const dateMatch = !eventDate || (String(dateParts[0]) === String(dateFromDataParts[2])) && (String(dateParts[1]) === String(dateFromDataParts[1])) && (String(dateParts[2]) === String(dateFromDataParts[0]));
        const monthMatch = eventMonth === "" || data.month === dateParts[1] || eventMonth === "00"
        if (typeMatch && monthMatch)
          filteredData.push({ id: event.id, name: event.eventOwnerName, firstDesc: event.eventType, secDesc: formattedDate, threeDesc: `${!(event.oneTimeEvent) && currentYear - dateParts[0] > 0 ? currentYear - dateParts[0] : ""}`, img: <CardMedia sx={{ height: '10vh' }} image={image} title="green iguana"></CardMedia> })
      })
      setEventRows(filteredData)
    }
    catch (error) {
      enqueueSnackbar(error)
    }
  }
  // const handleDateChange = (e) => {
  //   setEventDate(e)
  // }
  const handleTypeChange = (event) => {
    setEventType(event.target.value);
  };
  const handleMonthChange = (event) => {
    setEventMonth(event.target.value);
  };
  function createData(id, name, firstDesc, secDesc, threeDesc, img) {
    return { id, name, firstDesc, secDesc, threeDesc, img };
  }

  return (
    <>
      <Grid container justifyContent="space-around">
        <Grid item xs={6}>
          <Grid container color="gray" columnSpacing={{ xs: 1, sm: 2, md: 3 }} style={{ width: '100%' }}>
            <h4 justifyContent="space-evenly" alignItems="center">בחר את אפשרות הסינון הרצויה</h4>
          </Grid>
        </Grid>

        <Grid item sx={{mx:2}}>
          <Button
            variant="outlined"
            sx={{ mt: 3, mb: 2 }}
            onClick={exportToExcel}>
            יצא נתונים ל-excell
          </Button>
          {isEvents ? <Button
            variant="outlined"
            sx={{ mt: 3, mb: 2 }}
            onClick={() => { setIsEvents(false) }}>
            עבור לרשימת המשתמשים
          </Button> : <Button
            variant="outlined"
            sx={{ mt: 3, mb: 2 }}
            onClick={() => {
              console.log(typeof(usersRows[0].firstDesc))
               setIsEvents(true) }}>
            עבור לרשימת האירועים
          </Button>}
        </Grid>
      </Grid>

      <form onSubmit={handleSubmit}>
        <Stack spacing={2} direction="row" sx={{my:3}}>
          <FormControl sx={{ minWidth: 150 }} size='small' >
            <InputLabel id="demo-simple-select-label">סוג אירוע</InputLabel>
            <Select
              onChange={handleTypeChange}
              labelId="demo-simple-select-label"
              id="demo-simple-select-event-type"
              label="סוג ארוע"
              value={eventType}
              name="type"
            >
              <MenuItem sx={{ height: 35 }} value={''}></MenuItem>
              <MenuItem value={'יומולדת'}>יומולדת</MenuItem>
              <MenuItem value={'יום נישואין'}>יום נישואין</MenuItem>
              <MenuItem value={'יום השנה'}>יום השנה</MenuItem>
              <MenuItem value={'other'}>אחר</MenuItem>
            </Select>
          </FormControl>
          <FormControl sx={{ m: 1, minWidth: 170 }} size='small' >
            <InputLabel id="demo-simple-select-label">בחר חודש בשנה</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select-Month"
              label="בחר חודש בשנה"
              onChange={handleMonthChange}
              value={eventMonth}
              name="month"
            >
              <MenuItem sx={{ height: 35 }} value={'00'}></MenuItem>
              <MenuItem value={'01'}>ינואר</MenuItem>
              <MenuItem value={'02'}>פברואר</MenuItem>
              <MenuItem value={'03'}>מרץ</MenuItem>
              <MenuItem value={'04'}>אפריל</MenuItem>
              <MenuItem value={'05'}>מאי</MenuItem>
              <MenuItem value={'06'}>יוני</MenuItem>
              <MenuItem value={'07'}>יולי</MenuItem>
              <MenuItem value={'08'}>אוגוסט</MenuItem>
              <MenuItem value={'09'}>ספטמבר</MenuItem>
              <MenuItem value={'10'}>אוקטובר</MenuItem>
              <MenuItem value={'11'}>נובמבר</MenuItem>
              <MenuItem value={'12'}>דצמבר</MenuItem>
            </Select>
          </FormControl>
          <Button
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
            type="submit">סנן</Button>
        </Stack>
      </form >

      {isEvents&&eventRows.length>0&&<CalendarTable rows={eventRows}></CalendarTable>}
      {!isEvents &&<CalendarTable rows={usersRows}></CalendarTable>}
      {!eventRows.length > 0 && isEvents && <h2>אין נתונים להצגה</h2>}
    </>
  )
}
export default CalendarManage;