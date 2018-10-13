var express = require('express');
var router = express.Router();

var customerController = require('../controllers/customerController')
var productTypeController = require('../controllers/productTypeController')
var productController = require('../controllers/productController')

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

router.post('/productType/create', productTypeController.productType_create_post)
router.get('/productTypes', productTypeController.productType_list)
router.put('/productType/update/:code', productTypeController.productType_update_put)
router.delete('/productType/delete/:code', productTypeController.productType_delete)


router.post('/product/create', productController.product_create_post)
router.get('/products', productController.product_list)
router.delete('/product/delete/:id', productController.product_delete)
router.put('/product/update/:id', productController.product_update_put)

module.exports = router;
