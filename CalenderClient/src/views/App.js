import { useSelector } from 'react-redux';
import { RouterProvider } from 'react-router-dom';
import { SnackbarProvider } from 'notistack';
import router from '../router';

function App() {

  const user = useSelector(state => state.user)


  return (
    <SnackbarProvider maxSnack={3}>
      <RouterProvider router={router} >
      </RouterProvider>
    </SnackbarProvider>
  );
}

export default App;
