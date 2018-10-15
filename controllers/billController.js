var Bill = require('../models/bill')

exports.bill_list = (req, res) => {
  Bill.find()
  .exec((err, bills) => {
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }
    res.send({isSuccess: true, bills: bills})
  })
}

exports.bill_create_post = (req, res) => {
  if (!req.body) return res.send({isSuccess: false, error: 'Thiếu thông tin hóa đơn'})

  let bill = new Bill({
    code: req.body.code,
    customer: req.body.customer,
    employee: req.body.employee,
    created: req.body.created,
    totalPrice: req.body.totalPrice,
    status: req.body.status
  })

  bill.save((err, newBill) => {
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }
    res.send({isSuccess: true, bill: newBill})
  })
}

exports.bill_delete = (req, res) => {
  if (!req.params.id) return res.send({isSuccess: false, error: 'Thiếu thông tin hóa đơn'})

  Bill.findByIdAndRemove(req.params.id, (err, removedBill) => {
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }
    res.send({isSuccess: true, bill: removedBill})
  })
}

exports.bill_update_put = (req, res) => {
  if (!req.params.id) return res.send({isSuccess: false, error: 'Thiếu thông tin hóa đơn'})

  Bill.findByIdAndUpdate(req.params.id, req.body, {new: true}, (err, updatedBill) => {
    if (err) {
      console.error('Error: ' + err)
      return res.send({isSuccess: false, error: 'Lỗi hệ thống'})
    }

    res.send({isSuccess: true, bill: updatedBill})
  })
}