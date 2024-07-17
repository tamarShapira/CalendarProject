import { Navigate, createBrowserRouter } from 'react-router-dom';
import Login from './views/sign-in/login';
import Register from './views/sign-in/register';
import SelectCalendar from './views/calendar/select-calendar';
import SelectAction from './views/calendar/select-action';
import PageNotFound from './components/page_not_found';
import PrivateRoute from './components/private-route';
import HomePage from './views/home/home-page';
import FamilySettings from './views/family-settings/family-settings';
import About from './views/about/about';
import Calendar from './views/calendar/calendar';
import AddUser from './views/family-settings/add-user';
import AddEvent from './views/family-settings/add-event';
import CalendarManage from './views/calendar/calendar-manage';
import ForgotPassword from './views/sign-in/forgot-password.js';

const router = createBrowserRouter([

  {
    path:'/add-event',
    element:<AddEvent/>
  },
  {
    path:'/add-user',
    element:<AddUser/>
  },
  {
    path: '/',
    element: <Navigate to="/login" />,
  },
  {
    path: '/login',
    element: <Login />
  },
  {
    path: '/register',
    element: <Register />
  },
  {
    path: '/forgotPassword',
    element: <ForgotPassword />
  },
  {
    path: '/selectCalendar',
    element: <SelectCalendar />
  },
  
  {
    path: '/selectAction',
    element: <SelectAction />
  },
  {
    path: '/home',
    element: <PrivateRoute Component={HomePage} />,
    children: [
      {
        path: 'calendar',
        element: <Calendar/>
      },
      {
        path: 'family/settings',
        element: <FamilySettings />
      },
      {
        path: 'about',
        element: <About />
      },
      {
        path:'calendar-manage',
        element:<CalendarManage/>
      }
    ]
  },
  {
    path: "*",
    element: <PageNotFound />
  }
]);
export default router;