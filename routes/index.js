var express = require('express');
var router = express.Router();

var customerController = require('../controllers/customerController')
var loaiSPController = require('../controllers/LoaiSPController')
var productController = require('../controllers/productController')
var billController = require('../controllers/billController')

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

router.post('/customer/create', customerController.customer_create_post)
router.delete('/customer/delete/:customerId', customerController.customer_delete)
router.put('/customer/update/:customerId', customerController.customer_update_put)

router.post('/loaiSP/create', loaiSPController.loaiSP_create_post)
router.get('/dsLoaiSP', loaiSPController.loaiSP_list)
router.put('/loaiSP/update/:MaLoaiSP', loaiSPController.loaiSP_update_put)
router.delete('/loaiSP/delete/:MaLoaiSP', loaiSPController.loaiSP_delete)


router.post('/product/create', productController.product_create_post)
router.get('/products', productController.product_list)
router.delete('/product/delete/:code', productController.product_delete)
router.put('/product/update/:code', productController.product_update_put)

router.post('/bill/create', billController.bill_create_post)
router.delete('/bill/delete/:id', billController.bill_delete)
router.get('/bills', billController.bill_list)
router.put('/bill/update/:id', billController.bill_update_put)

module.exports = router;
