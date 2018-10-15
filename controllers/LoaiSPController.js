var LoaiSP = require('../models/LoaiSP')
var SanPham = require('../models/SanPham')
var async = require('async')

exports.loaiSP_list = function (req, res) {
  LoaiSP.find()
  .exec(function(err, ds_loaiSP) {
    if (err) return res.send({isSuccess: false, error: err.toString()})
    res.send({isSuccess: true, ds_loaiSP: ds_loaiSP})
  })
}

exports.loaiSP_create_post = (req, res) => {

  if (!req.body.MaLoaiSP) return res.send({isSuccess: false, error: 'Thiếu mã loại sản phẩm'})
  if (!req.body.TenLoaiSP) return res.send({isSuccess: false, error: 'Thiếu tên loại sản phẩm'})

  async.waterfall([
    (done) => {
      LoaiSP.findOne({MaLoaiSP: req.body.MaLoaiSP})
      .exec((err, found) => {
        if (err) return done(err, null)
        if (found) return done('Mã loại sản phẩm đã tồn tại', null)
        done(null)
      })
    },
    (done) => {
      let loaiSP = new LoaiSP ({
        MaLoaiSP: req.body.MaLoaiSP,
        TenLoaiSP: req.body.TenLoaiSP
      })
    
      loaiSP.save((err, _loaiSP) => {
        if (err) return done('Lưu thất bại', null)
        done(null, _loaiSP)
      })
    }
  ], (err, _loaiSP) => {
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: err})
    }
    res.send({isSuccess: true, loaiSP: _loaiSP})
  })
}


exports.loaiSP_update_put = (req, res) => {
  if (!req.params.MaLoaiSP) return res.send({isSuccess: false, error: `Thiếu mã loại sản phẩm`})
  if (!req.body.MaLoaiSP) return res.send({isSuccess: false, error: 'Thiếu mã loại sản phẩm'})
  if (!req.body.TenLoaiSP) return res.send({isSuccess: false, error: 'Thiếu tên loại sản phẩm'})

  
  LoaiSP.findOneAndUpdate({MaLoaiSP: req.params.MaLoaiSP}, req.body, {new: true}, (err, _loaiSP) => {
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: 'Cập nhật thất bại'})
    }
    res.send({isSuccess: true, loaiSP: _loaiSP})
  })
}

exports.loaiSP_delete = (req, res) => {
  if (!req.params.MaLoaiSP) return res.send({isSuccess: false, error: 'Thiếu mã loại sản phẩm'})

  async.waterfall([
    // // check references
    // (done) => {
    //   Product.findOne({type: req.params.id})
    //   .exec((err, found) => {
    //     if (err) {
    //       console.error('Error: ' + err)
    //       return done('Lỗi hệ thống', null)
    //     }
    //     if (found) return done('Không thể xóa, Loại sản phẩm đang được sử dụng')
    //     done(null)
    //   })
    // },
    // delete product type
    (done) => {
      LoaiSP.findOneAndRemove({MaLoaiSP : req.params.MaLoaiSP}, (err, _loaiSP) => {
        if (err) {
          console.error('Error: ' + err)
          return done('Lỗi hệ thống', null)
        }
        done(null, _loaiSP)
      })
    }
  ], (err, _loaiSP) => {
    if (err) return res.send({isSuccess: false, error: err})
    res.send({isSuccess: true, loaiSP: _loaiSP})
  })
}