var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});

router.get('/employee', function(req, res) {
  let employee = 
  {
    code: 'NV001',
    name: 'Nguyên cờ hó'
  }
  res.send(employee)
})

router.post('/employee/create', function (req, res) {
	console.log(JSON.stringify(req.body))
})

module.exports = router;
