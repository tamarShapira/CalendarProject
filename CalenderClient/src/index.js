import React from 'react';
import ReactDOM from 'react-dom/client';
import './styles/index.css';
import App from './views/App';
import { Provider } from 'react-redux';
import store from './store';
import {ThemeProvider} from '@mui/material/styles';
import rtlPlugin from 'stylis-plugin-rtl';
import {prefixer} from 'stylis';
import {CacheProvider} from '@emotion/react';
import createCache from '@emotion/cache';
import { CssBaseline } from '@mui/material/';
import theme from './styles/theme';

const cacheRtl = createCache({
  key: 'muirtl',
  stylisPlugins: [prefixer, rtlPlugin],
});

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <Provider store={store}>
      <CacheProvider value={cacheRtl}>
        <ThemeProvider theme={theme}>
          <CssBaseline/>
            <App />
          </ThemeProvider>
      </CacheProvider>
    </Provider>
  </React.StrictMode>
);