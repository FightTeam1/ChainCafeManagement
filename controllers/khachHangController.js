var KhachHang = require('../models/KhachHang')
var md5 = require('md5')

exports.khachHang_create_post = function (req, res) {
  if (!req.body) return res.send({isSuccess: false, error: 'Thiếu thông tin khách hàng'})
  let khachHang = new KhachHang({
    TenDangNhap: req.body.TenDangNhap,
    HoTen: req.body.HoTen,
    Sdt: req.body.Sdt,
    Email: req.body.Email,
    Diem: 0,
    MatKhau: md5(req.body.MatKhau)
  })

  khachHang.save(function (err, _khachHang) {
    if (err) return res.send({isSuccess: false, error: err.toString()})
    res.send({isSuccess: true, khachHang: _khachHang})
  })
}

exports.khachHang_delete = function (req, res) {
  if (!req.params.TenDangNhap) return res.send({isSuccess: false, error: 'Thiếu thông tin khách hàng cần xóa'})
  KhachHang.findOneAndRemove({TenDangNhap: req.params.TenDangNhap}, function (err, _khachHang) {
    if (err) return res.send({isSuccess: false, error: err.toString()})
    res.send({isSuccess: true, khachHang: _khachHang})
  })
}

exports.khachHang_update_put = function (req, res) {
  if (!req.params.TenDangNhap) return res.send({isSuccess: false, error: 'Thiếu thông tin khách hàng cần cập nhật'})
  if (!req.body) return res.send({isSuccess: false, error: 'Thiếu thông tin khách hàng cần cập nhật'})
  
  KhachHang.findOne({TenDangNhap: req.params.TenDangNhap})
  .exec(function (err, toUpdateKhachHang) {
    if (err) return res.send({isSuccess: false, error: err.toString()})
    if (!toUpdateKhachHang) return res.send({isSuccess: false, error: 'Khách hàng không tồn tại'})

    toUpdateKhachHang.TenDangNhap = req.body.TenDangNhap
    toUpdateKhachHang.HoTen = req.body.HoTen
    toUpdateKhachHang.Sdt = req.body.Sdt
    toUpdateKhachHang.Email = req.body.Email
    toUpdateKhachHang.Diem = req.body.Diem
    // not update password here
    
    toUpdateKhachHang.save(function (err, _khachHang) {
      if (err) return res.send({isSuccess: false, error: err.toString()})
      res.send({isSuccess: true, khachHang: _khachHang})
    })
  })
}