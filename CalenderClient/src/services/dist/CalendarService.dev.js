"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports["default"] = void 0;

var _axios = _interopRequireDefault(require("axios"));

var _config = require("../config");

var _AuthService = _interopRequireDefault(require("./AuthService"));

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { "default": obj }; }

function ownKeys(object, enumerableOnly) { var keys = Object.keys(object); if (Object.getOwnPropertySymbols) { var symbols = Object.getOwnPropertySymbols(object); if (enumerableOnly) symbols = symbols.filter(function (sym) { return Object.getOwnPropertyDescriptor(object, sym).enumerable; }); keys.push.apply(keys, symbols); } return keys; }

function _objectSpread(target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i] != null ? arguments[i] : {}; if (i % 2) { ownKeys(source, true).forEach(function (key) { _defineProperty(target, key, source[key]); }); } else if (Object.getOwnPropertyDescriptors) { Object.defineProperties(target, Object.getOwnPropertyDescriptors(source)); } else { ownKeys(source).forEach(function (key) { Object.defineProperty(target, key, Object.getOwnPropertyDescriptor(source, key)); }); } } return target; }

function _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }

var baseUrl = "".concat(_config.API_URL, "/Calendar");
var CalendarService = {
  addCalendar: function addCalendar(data) {
    return _axios["default"].post(baseUrl, _objectSpread({}, data));
  },
  getCalendars: function getCalendars() {
    return _axios["default"].get(baseUrl, {
      headers: _AuthService["default"].authHeader()
    });
  },
  // getAllCalendars:function(){
  //   return axios.get(baseUrl);
  // },
  // getUserCalendars: function() {
  //   return axios.get(baseUrl, { headers: AuthService.authHeader(), params: { userId } });
  // },
  getCalendarUsers: function getCalendarUsers(calendarId) {
    return _axios["default"].get(baseUrl + '/users', {
      headers: _AuthService["default"].authHeader(),
      params: {
        calendarId: calendarId
      }
    });
  }
};
var _default = CalendarService;
exports["default"] = _default;
//# sourceMappingURL=CalendarService.dev.js.map
