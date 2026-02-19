module.exports = (req, res, next) => {
  res.header("Access-Control-Allow-Origin", "*"); // Or set to your frontend origin for tighter security
  res.header("Access-Control-Allow-Methods", "GET,POST,PATCH,PUT,DELETE,OPTIONS");
  res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
  next();
};