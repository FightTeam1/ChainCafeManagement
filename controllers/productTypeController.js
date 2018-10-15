var ProductType = require('../models/productType')
var Product = require('../models/product')
var async = require('async')

exports.productType_list = function (req, res) {
  ProductType.find()
  .exec(function(err, productTypes) {
    if (err) return res.send({isSuccess: false, error: err.toString()})
    res.send({isSuccess: true, productTypes: productTypes})
  })
}

exports.productType_create_post = (req, res) => {
  console.log('============ ' + req.body)
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
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: err})
    }
    res.send({isSuccess: true, productType: newProductType})
  })
}


exports.productType_update_put = (req, res) => {
  if (!req.params.code) return res.send({isSuccess: false, error: `Thiếu loại sản phẩm`})
  if (!req.body.code) return res.send({isSuccess: false, error: 'Thiếu mã loại sản phẩm'})
  if (!req.body.name) return res.send({isSuccess: false, error: 'Thiếu tên loại sản phẩm'})

  
  ProductType.findOneAndUpdate({code: req.params.code}, req.body, {new: true}, (err, updatedProductType) => {
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: 'Cập nhật thất bại'})
    }
    res.send({isSuccess: true, productType: updatedProductType})
  })
}

exports.productType_delete = (req, res) => {
  if (!req.params.code) return res.send({isSuccess: false, error: 'Thiếu loại sản phẩm'})

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
      ProductType.findOneAndRemove({code: req.params.code}, (err, deletedProductType) => {
        if (err) {
          console.error('Error: ' + err)
          return done('Lỗi hệ thống', null)
        }
        done(null, deletedProductType)
      })
    }
  ], (err, product) => {
    if (err) return res.send({isSuccess: false, error: err})
    res.send({isSuccess: true, product: product})
  })
}