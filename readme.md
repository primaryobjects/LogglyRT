Loggly WinRT Driver
--------

A simple WinRT (Windows 8 App Store) driver for [loggly.com](http://loggly.com/).

## Usage

Asynchronous

```
var logger = new Logger("your-loggly-api-key");
logger.Log("Hello World!");
```

Synchronous

```
var logger = new Logger("your-loggly-api-key");
await logger.Log("Hello World!");
```

Custom

```
var logger = new Logger("your-loggly-api-key", "https://logs.loggly.com/inputs/", "application/json");
await logger.Log("{\"message\":\"Hello World!\"}");
```

## Author

Kory Becker
http://www.primaryobjects.com

View @ GitHub
https://github.com/primaryobjects/logglyrt