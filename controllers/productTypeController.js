var ProductType = require('../models/productType')
var async = require('async')

exports.productType_list = function (req, res) {
  ProductType.find()
  .exec(function(err, productTypes) {
    if (err) return res.send({isSuccess: false, error: err.toString()})
    res.send({isSuccess: true, productTypes: productTypes})
  })
}

exports.productType_create_post = (req, res) => {
  if (!req.body.code) return res.send({isSuccess: false, error: 'Thiếu mã loại sản phẩm'})
  if (!req.body.name) return res.send({isSuccess: false, error: 'Thiếu tên loại sản phẩm'})

  async.waterfall([
    (done) => {
      ProductType.findOne({code: req.body.code})
      .exec((err, found) => {
        if (err) return done(err, null)
        if (found) return done('Mã loại sản phẩm đã tồn tại', null)
        done(null)
      })
    },
    (done) => {
      ProductType.findOne({name: req.body.name})
      .exec((err, found) => {
        if (err) return done(err, null)
        if (found) return done('Tên loại sản phẩm đã tồn tại', null)
        done(null)
      })
    },
    (done) => {
      let productType = new ProductType({
        code: req.body.code,
        name: req.body.name
      })
    
      productType.save((err, newProductType) => {
        if (err) return done('Lưu thất bại', null)
        done(null, newProductType)
      })
    }
  ], (err, newProductType) => {
    if (err) return res.send({isSuccess: false, error: err})
    res.send({isSuccess: true, productType: newProductType})
  })
}


exports.productType_update_put = (req, res) => {
  if (!req.params.code) return res.send({isSuccess: false, error: `Loại sản phẩm ${req.params.code} không tồn tại`})
  if (!req.body.code) return res.send({isSuccess: false, error: 'Thiếu mã loại sản phẩm'})
  if (!req.body.name) return res.send({isSuccess: false, error: 'Thiếu tên loại sản phẩm'})



  ProductType.findOneAndUpdate({code: req.params.code}, req.body, {new: true}, (err, updatedProductType) => {
    if (err) return res.send({isSuccess: false, error: 'Cập nhật thất bại'})
    res.send({isSuccess: true, productType: updatedProductType})
  })
}

exports.productType_delete = (req, res) => {
  if (!req.params.code) return res.send({isSuccess: false, error: 'Không tìm thấy loại sản phẩm ' + req.params.code})

  ProductType.findOneAndRemove({code: req.params.code}, (err, deletedProductType) => {
    if (err) return res.send({isSuccess: false, error: 'Xóa thất bại'})
    res.send({isSuccess: true, productType: deletedProductType})
  })
}