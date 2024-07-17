import * as React from 'react';
import TableBody from '@mui/material/TableBody';
import TableContainer from '@mui/material/TableContainer';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Table from '@mui/material/Table';
import { styled } from '@mui/material/styles';
import Paper from '@mui/material/Paper';

const CalendarTable = ({rows}) => {

    const StyledTableCell = styled(TableCell)(({ theme }) => ({
        [`&.${tableCellClasses.head}`]: {
            backgroundColor: theme.palette.common.black,
            color: theme.palette.common.white,
        },
        [`&.${tableCellClasses.body}`]: {
            fontSize: 14,
        },
    }));
    const StyledTableRow = styled(TableRow)(({ theme }) => ({
        '&:nth-of-type(odd)': {
            backgroundColor: theme.palette.action.hover,
        },
        // hide last border
        '&:last-child td, &:last-child th': {
            border: 0,
        },
    }));
    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 700 }} aria-label="customized table">
            <TableHead>
               <TableRow>
                 <StyledTableCell>שם </StyledTableCell>
                 <StyledTableCell align='right'>{typeof(rows[0].firstDesc)=="number"?'תעודת זהות':"סוג אירוע"}</StyledTableCell>
                 <StyledTableCell align="right">{typeof(rows[0].firstDesc)=="number"?'מספר טלפון':"תאריך אירוע"}</StyledTableCell>
                 <StyledTableCell align='center'>{typeof(rows[0].firstDesc)=="number"?'כתובת מייל':"מספר שנים לאירוע"}</StyledTableCell>
                 <StyledTableCell align="right"></StyledTableCell>
               </TableRow>
             </TableHead>
             <TableBody>
               {rows.map((row) => (
                 <StyledTableRow key={row.id}>
                   <StyledTableCell component="th" scope="row">
                     {row.name}
                   </StyledTableCell>
                   <StyledTableCell align="right">{row.firstDesc}</StyledTableCell>
                   <StyledTableCell align="right">{row.secDesc}</StyledTableCell>
                   <StyledTableCell align='center'>{row.threeDesc}</StyledTableCell>
                   <StyledTableCell align="right">{row.img}</StyledTableCell>
                 </StyledTableRow>
               ))}
             </TableBody>
           </Table>
         </TableContainer>
    );
}
export default CalendarTable;