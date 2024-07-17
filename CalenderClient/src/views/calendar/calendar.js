import React,{useEffect} from 'react';
import { useDispatch, useSelector } from "react-redux";
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid' // a plugin!
import heLocale from '@fullcalendar/core/locales/he';
import { getCalendarEvents } from '../../store/actions/calendar-actions';

const Calendar = () => {

  const { calendars } = useSelector(state => state.calendar);
  const currentCalendar = calendars.find(calendar => calendar.active);
  const calendarUsers = currentCalendar.users;
  const eventsList = currentCalendar.events

  const currentYear = new Date().getFullYear();

  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(getCalendarEvents(currentCalendar.id))
  },[])

  function renderEventContent(eventInfo) {
    return (
      <>
        <b>{eventInfo.timeText}</b>
        <i>{eventInfo.event.title}</i>
      </>
    )
  }

  return (
    <FullCalendar
    // dangerouslySetInnerHTML={{ __html: calendarData }}
      plugins={[dayGridPlugin]}
      locale={heLocale}
      initialView="dayGridMonth"
      eventContent={renderEventContent}
      events={
        eventsList.map(eevent => {
          const dateParts = eevent.gregorianDate.split('-');
          const formattedDate = `${currentYear}-${dateParts[1]}-${dateParts[2]}`

          const eventOwner = calendarUsers.find(user => user.id === eevent.userId);
          if (eventOwner) {
            return {

              title: `${eevent.eventType} ${!(eevent.oneTimeEvent) && currentYear - dateParts[0] > 0 ? currentYear - dateParts[0] : ""} - ${eevent.eventOwnerName}`,
              date: formattedDate
            };
          }
          return {
            title: eevent.eventType,
            date: eevent.gregorianDate,
         
          };

        })
      }
    />
  );
}
export default Calendar;