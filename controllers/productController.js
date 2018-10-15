var Product = require('../models/product')
var ProductType = require('../models/productType')
var async = require('async')

exports.product_create_post = (req, res) => {
  if (!req.body.code) return res.send({isSuccess: false, error: 'Thiếu mã sản phẩm'})
  if (!req.body.name) return res.send({isSuccess: false, error: 'Thiếu tên sản phẩm'})
  if (!req.body.productTypeCode) return res.send({isSuccess: false, error: 'Thiếu loại sản phẩm'})

  async.waterfall([
    (done) => {
      Product.findOne({code: req.body.code})
      .exec((err, foundProduct) => {
        if (err) {
          console.error(err)
          return done('Lỗi hệ thống', null)
        }
        if (foundProduct) return done('Mã sản phẩm đã tồn tại', null)
        done(null)
      })
    },

    (done) => {
      ProductType.findOne({code: req.body.productTypeCode})
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
      let product = new Product({
        code: req.body.code,
        name: req.body.name,
        productTypeCode: req.body.productTypeCode
      })

      product.save((err, newProduct) => {
        if (err) {
          console.error(err)
          return done('Lỗi hệ thống', null)
        }
        done(null, newProduct)
      })
    }
  ], (err, newProduct) => {
    if (err) return  res.send({isSuccess: false, error: err})
    res.send({isSuccess: true, product: newProduct})
  })
}

exports.product_list = (req, res) => {
  Product.find()
  .exec((err, products) => {
    if (err) {
      console.error(err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }

    res.send({isSuccess: true, products: products})
  })
}

exports.product_delete = (req, res) => {
  if (!req.params.id) return res.send({isSuccess: false, error: 'Thiếu id sản phẩm'})
  
  Product.findByIdAndRemove(req.params.id, (err, removedProduct) => {
    if (err) {
      console.error(err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }
    res.send({isSuccess: true, product: removedProduct})
  })
}

exports.product_update_put = (req, res) => {
  if (!req.params.id) return res.send({isSuccess: false, error: 'Thiếu id sản phẩm'})
  if (!req.body.code) return res.send({isSuccess: false, error: 'Thiếu mã sản phẩm'})
  if (!req.body.name) return res.send({isSuccess: false, error: 'Thiếu tên sản phẩm'})
  if (!req.body.type) return res.send({isSuccess: false, error: 'Thiếu loại sản phẩm'})

  Product.findByIdAndUpdate(req.params.id, req.body, {new: true}, (err, updatedProduct) => {
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }

    res.send({isSuccess: true, product: updatedProduct})
  })
}