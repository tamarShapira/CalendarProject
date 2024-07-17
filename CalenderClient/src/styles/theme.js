import {createTheme} from '@mui/material/styles';

const theme = createTheme({
    direction: 'rtl',
    typography: {
      "fontFamily": "system-ui"
    },
    palette: {
      primary: {
        main: '#FF5733',
      },
      secondary: {
        main: '#E0C2FF',
        light: '#F5EBFF',
        contrastText: '#47008F',
      },
    },
    components: {
      MuiPaper: {
        styleOverrides: {
          root: {
            backgroundColor: "#fff7f3"
          }
        }
      }
    }
});

export default theme;  