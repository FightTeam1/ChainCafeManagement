var ProductType = require('../models/productType')

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

  let productType = new ProductType({
    code: req.body.code,
    name: req.body.name
  })

  productType.save((err, newProductType) => {
    if (err) return res.send({isSuccess: false, error: 'Lưu thất bại'})
    res.send({isSuccess: true, productType: newProductType})
  })
}


exports.productType_update_put = (req, res) => {
  if (!req.params.productTypeId) return res.send({isSuccess: false, error: 'Loại sản phẩm không tồn tại'})
  if (!req.body.code) return res.send({isSuccess: false, error: 'Thiếu mã loại sản phẩm'})
  if (!req.body.name) return res.send({isSuccess: false, error: 'Thiếu tên loại sản phẩm'})

  ProductType.findByIdAndUpdate(req.params.productTypeId, req.body, {new: true}, (err, updatedProductType) => {
    if (err) return res.send({isSuccess: false, error: 'Cập nhật thất bại'})
    res.send({isSuccess: true, productType: updatedProductType})
  })
}