var express = require('express');
var router = express.Router();

var khachHangController = require('../controllers/khachHangController')
var loaiSPController = require('../controllers/loaiSPController')
var sanPhamController = require('../controllers/sanPhamController')
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

router.post('/khachHang/create', khachHangController.khachHang_create_post)
router.delete('/khachHang/delete/:TenDangNhap', khachHangController.khachHang_delete)
router.put('/khachHang/update/:TenDangNhap', khachHangController.khachHang_update_put)

router.post('/loaiSP/create', loaiSPController.loaiSP_create_post)
router.get('/dsLoaiSP', loaiSPController.loaiSP_list)
router.put('/loaiSP/update/:MaLoaiSP', loaiSPController.loaiSP_update_put)
router.delete('/loaiSP/delete/:MaLoaiSP', loaiSPController.loaiSP_delete)


router.post('/sanPham/create', sanPhamController.sanPham_create_post)
router.get('/dsSanPham', sanPhamController.sanPham_list)
router.delete('/sanPham/delete/:MaSP', sanPhamController.sanPham_delete)
router.put('/sanPham/update/:MaSP', sanPhamController.sanPham_update_put)

router.post('/bill/create', billController.bill_create_post)
router.delete('/bill/delete/:id', billController.bill_delete)
router.get('/bills', billController.bill_list)
router.put('/bill/update/:id', billController.bill_update_put)

module.exports = router;
