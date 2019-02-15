import fetch from 'dva/fetch';
import config from './config'
import com from './commom'
function parseJSON(response) {
  debugger
  return response.json();
}

function checkStatus(response) {
  if (response.status >= 200 && response.status < 300) {
    return response;
  }

  const error = new Error(response.statusText);
  error.response = response;
  throw error;
}

/**
 * Requests a URL, returning a promise.
 *
 * @param  {string} url       The URL we want to request
 * @param  {object} [options] The options we want to pass to "fetch"
 * @return {object}           An object containing either "data" or "err"
 */
export default function request(url, options) {
  var token=com.GetPkey();
  if (options.headers) {
    options.headers['Accept'] = 'application/json';
    options.headers['Authorization'] = token
    //options.headers['Content-Type'] = 'application/json;charset=UTF-8';
  } else {
    options.headers = {
      'Content-Type': 'application/json',//'application/json',
      'Authorization': token
    }
  }


  var httpUrl;

  if(url.indexOf('http')>-1||url.indexOf('http')>-1){
    httpUrl=url;
  }else{
    httpUrl=config.ip+url;
  }
  return fetch(`${httpUrl}`, options)
    .then(checkStatus)
    .then(parseJSON)
    .then(data => ({ data }))
    .catch(err => ({ err }));
}
