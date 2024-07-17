import * as React from 'react';
import { Link as RouterLink } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import router from '../../router';
import { logout } from '../../store/actions/auth-actions';
import ExitToAppIcon from '@mui/icons-material/ExitToApp';
import ManageAccountsIcon from '@mui/icons-material/ManageAccounts';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import Link from '@mui/material/Link';
import MenuIcon from '@mui/icons-material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import PersonIcon from '@mui/icons-material/Person';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';

const Navbar = () => {
  const dispatch = useDispatch();
  const siteUser = useSelector(state => state.user);
  const [anchorElNav, setAnchorElNav] = React.useState(null);
  const [anchorElUser, setAnchorElUser] = React.useState(null);
  const { calendars } = useSelector(state => state.calendar);
  const currentCalendar = calendars.find(calendar => calendar.active) ? calendars.find(calendar => calendar.active) : null;
  const { disabledButton } = currentCalendar ? true : false;

  const pages = [
    { name: "calendar", text: 'לוח שנה', link: "/home/calendar",action: () => { router.navigate('/home/calendar')}} ,
    { name: "manage-family", text: 'ניהול בני משפחה ואירועים ', link: "/home/family/settings",action: () => { router.navigate('/home/family/settings')} },
    { name: "manage-calendar", text: 'פרטי לוח', link: "/home/calendar-manage" ,action: () => { router.navigate('/home/calendar-manage')}},
    { name: "about", text: 'אודות', link: "/home/about",action: () => { router.navigate('/home/about')} }

  ];

  const settings = [
    { name: 'User', text: `${siteUser.user.firstName} ${siteUser.user.lastName}`, icon: <PersonIcon size="small" style={{ minWidth: '40px', marginBottom: '-6px' }} />, action: () => { currentCalendar && router.navigate('/home/family/settings') } },
    { name: 'Settings', text: "הגדרות חשבון", icon: <ManageAccountsIcon size="small" style={{ minWidth: '40px', marginBottom: '-6px' }} />, action: () => { router.navigate('/home/user-settings') } },
    { name: 'Logout', text: "יציאה", icon: <ExitToAppIcon size="small" style={{ minWidth: '40px', marginBottom: '-6px' }} />, action: () => { dispatch(logout()) } }
  ];

  function stringAvatar(name) {
    return {
      children: `${name.split(' ')[0][0]}${name.split(' ')[1][0]}`,
    };
  }
  const handleOpenNavMenu = (event) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    console.log("siteUser: ", siteUser)
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  return (
    <AppBar position="static">
      <Container>
        <Toolbar disableGutters>
          <Link component={RouterLink} to="/selectCalendar" underline="none" color='inherit'>
            <CalendarMonthIcon sx={{ display: { xs: 'none', md: 'flex' }, mr: 1 }} />
            <Typography
              variant="h6"
              noWrap
              component="a"
              sx={{
                mr: 6,
                display: { xs: 'none', md: 'flex' },
                fontWeight: 700,
                letterSpacing: '.1rem',
                color: 'inherit',
                textDecoration: 'none',
                marginTop: '-4px'
              }}
            >
              קלנדר
            </Typography>
          </Link>
          <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
            <Tooltip>
              <IconButton
                size="large"
                aria-label="account of current user"
                aria-controls="menu-appbar"
                aria-haspopup="true"
                onClick={handleOpenNavMenu}
                color="inherit"
              >
                <MenuIcon />
              </IconButton>
            </Tooltip>
            <Menu
              sx={{ mt: '45px' }}
              id="menu-appbar"
              anchorEl={anchorElNav}

              anchorOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
            >
              {pages.map((page) => (
                <MenuItem key={page.name} onClick={page.action} disabled={!currentCalendar}>
                  <Typography textAlign="center"> {page.icon}{page.text}</Typography>
                </MenuItem>
              ))}
            </Menu>
          </Box>

          <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
            {pages.map(({ name, text, link }) => (
              <Button
                key={name}
                onClick={() => {
                  handleCloseNavMenu();
                }
                }
                disabled={!currentCalendar}

                sx={{ my: 2, color: 'white', display: 'block' }}
                component={RouterLink}
                to={link}
              >
                {text}
              </Button>
            ))}
          </Box>

          <Box sx={{ flexGrow: 0 }}>
            <Tooltip title="Open settings">
              <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                <Avatar {...stringAvatar(`${siteUser.user.firstName} ${siteUser.user.lastName}`)} />
              </IconButton>
            </Tooltip>
            <Menu
              sx={{ mt: '45px' }}
              id="menu-appbar"
              anchorEl={anchorElUser}
              anchorOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              open={Boolean(anchorElUser)}
              onClose={handleCloseUserMenu}
            >
              {settings.map((setting) => (
                <MenuItem key={setting.name} onClick={setting.action}>
                  <Typography textAlign="center"> {setting.icon}{setting.text}</Typography>
                </MenuItem>
              ))}
            </Menu>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}
export default Navbar;