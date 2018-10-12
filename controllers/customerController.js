var Customer = require('../models/customer')
var md5 = require('md5')

exports.customer_create_post = function (req, res) {
  if (!req.body) return res.send({isSuccess: false, error: 'Thiếu thông tin khách hàng'})
  let customer = new Customer({
    loginName: req.body.loginName,
    fullName: req.body.fullName,
    phoneNumber: req.body.phoneNumber,
    email: req.body.email,
    score: 0,
    password: md5(req.body.password)
  })

  customer.save(function (err, newCustomer) {
    if (err) return res.send({isSuccess: false, error: err.toString()})
    res.send({isSuccess: true, customer: newCustomer})
  })
}

exports.customer_delete = function (req, res) {
  if (!req.params.customerId) return res.send({isSuccess: false, error: 'Thiếu thông tin khách hàng cần xóa'})
  Customer.findByIdAndRemove(req.params.customerId, function (err, removedCustomer) {
    if (err) return res.send({isSuccess: false, error: err.toString()})
    res.send({isSuccess: true, customer: removedCustomer})
  })
}

exports.customer_update_put = function (req, res) {
  if (!req.params.customerId) return res.send({isSuccess: false, error: 'Thiếu thông tin khách hàng cần cập nhật'})
  if (!req.body) return res.send({isSuccess: false, error: 'Thiếu thông tin khách hàng cần cập nhật'})
  
  Customer.findById(req.params.customerId)
  .exec(function (err, toUpdateCustomer) {
    if (err) return res.send({isSuccess: false, error: err.toString()})
    if (!toUpdateCustomer) return res.send({isSuccess: false, error: 'Khách hàng không tồn tại'})

    toUpdateCustomer.loginName = req.body.loginName
    toUpdateCustomer.fullName = req.body.fullName
    toUpdateCustomer.phoneNumber = req.body.phoneNumber
    toUpdateCustomer.email = req.body.email
    toUpdateCustomer.score = req.body.score
    // not update password here
    
    toUpdateCustomer.save(function (err, updatedCustomer) {
      if (err) return res.send({isSuccess: false, error: err.toString()})
      res.send({isSuccess: true, customer: updatedCustomer})
    })
  })
}