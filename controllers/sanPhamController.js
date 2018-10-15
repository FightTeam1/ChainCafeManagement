var SanPham = require('../models/SanPham')
var LoaiSP = require('../models/LoaiSP')
var async = require('async')

exports.sanPham_create_post = (req, res) => {
  if (!req.body.MaSP) return res.send({isSuccess: false, error: 'Thiếu mã sản phẩm'})
  if (!req.body.TenSP) return res.send({isSuccess: false, error: 'Thiếu tên sản phẩm'})
  if (!req.body.MaLoaiSP) return res.send({isSuccess: false, error: 'Thiếu mã loại sản phẩm'})

  async.waterfall([
    (done) => {
      SanPham.findOne({MaSP: req.body.MaSP})
      .exec((err, found) => {
        if (err) {
          console.error(err)
          return done('Lỗi hệ thống', null)
        }
        if (found) return done('Mã sản phẩm đã tồn tại', null)
        done(null)
      })
    },

    (done) => {
      LoaiSP.findOne({MaLoaiSP: req.body.MaLoaiSP})
      .exec((err, found) => {
        if (err) {
          console.error(err)
          return done('Lỗi hệ thống', null)
        }
        if (!found) return done('Loại sản phẩm không tồn tại', null)
        done(null)
      })
    },

    (done) => {
      let sanPham = new SanPham({
        MaSP: req.body.MaSP,
        TenSP: req.body.TenSP,
        MaLoaiSP: req.body.MaLoaiSP
      })

      sanPham.save((err, _sanPham) => {
        if (err) {
          console.error(err)
          return done('Lỗi hệ thống', null)
        }
        done(null, _sanPham)
      })
    }
  ], (err, _sanPham) => {
    if (err) return  res.send({isSuccess: false, error: err})
    res.send({isSuccess: true, sanPham: _sanPham})
  })
}

exports.sanPham_list = (req, res) => {
  SanPham.find()
  .exec((err, ds_sanPham) => {
    if (err) {
      console.error(err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }

    res.send({isSuccess: true, ds_sanPham: ds_sanPham})
  })
}

exports.sanPham_delete = (req, res) => {
  if (!req.params.MaSP) return res.send({isSuccess: false, error: 'Thiếu mã sản phẩm'})
  
  SanPham.findOneAndRemove({MaSP: req.params.MaSP}, (err, _sanPham) => {
    if (err) {
      console.error(err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }
    res.send({isSuccess: true, sanPham: _sanPham})
  })
}

exports.sanPham_update_put = (req, res) => {
  if (!req.params.MaSP) return res.send({isSuccess: false, error: 'Thiếu mã sản phẩm'})
  if (!req.body.MaSP) return res.send({isSuccess: false, error: 'Thiếu mã sản phẩm'})
  if (!req.body.TenSP) return res.send({isSuccess: false, error: 'Thiếu tên sản phẩm'})
  if (!req.body.MaLoaiSP) return res.send({isSuccess: false, error: 'Thiếu mã loại sản phẩm'})

  SanPham.findOneAndUpdate({MaSP: req.params.MaSP}, req.body, {new: true}, (err, _sanPham) => {
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }

    res.send({isSuccess: true, sanPham: _sanPham})
  })
}