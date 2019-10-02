var homeConfig = {
    pageSize: 12,
    pageIndex: 1,
}
var homeController = {
    init: function () {
        homeController.loadData();
        homeController.registerEvent();       
    },
    registerEvent: function () {

        $('.txtSalary').off('keypress').on('keypress', function (e) {
            if (e.which == 13)
            {
                var id = $(this).data('id');
                var value = $(this).val();
                homeController.updateSalary(id, value);
            }
        });
        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            homeController.resetForm();
        });

        $('#btnSave').off('click').on('click', function () {
            homeController.saveData();
        });
        $('.btn-edit').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            var id = $(this).data('id');
            homeController.loadDetail(id);
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                message: "Are you sure to delete?",
                buttons: {
                    confirm: {
                        label: 'Yes',
                        className: 'btn-danger'
                    },
                    cancel: {
                        label: 'No',
                        className:'btn-success'
                    }
                },
                callback: function(result) {
                    if (result === true) {
                        homeController.deleteEmployee(id);
                    }
                }
            });
        });
    },
    loadDetail: function (id) {
        $.ajax({
            url: '/Home/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.ID);
                    $('#txtName').val(data.Name);
                    $('#txtSalary').val(data.Salary);
                    $('#ckStatus').prop('checked', data.Status);
                }
                else {
                    alert(response.Message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    },
    saveData: function () {
        var name = $('#txtName').val();
        var salary = parseFloat($('#txtSalary').val());
        var status = $('#ckStatus').prop('checked');
        var id = parseInt($('#hidID').val());
        var employee = {
            Name: name,
            Salary: salary,
            Status: status,
            ID: id
        };
        $.ajax({
            url: '/Home/SaveData',
            data: {
                strEmployee: JSON.stringify(employee)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    alert('Save Successful');
                    $('#modalAddUpdate').modal('hide');
                    homeController.loadData();
                }
                else {
                    alert(response.message);
                    $('#modalAddUpdate').modal('hide');
                    homeController.loadData();
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    },
    deleteEmployee: function (id) {
        $.ajax({
            url: '/Home/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    alert('Delete Successful');
                    homeController.loadData();
                }
                else {
                    alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    },
    resetForm: function () {
        $('#hidID').val('0');
        $('#txtName').val('');
        $('#txtSalary').val(0);
        $('#ckStatus').prop('checked', true);

    },
    updateSalary: function (id, value) {
        var data = {
            ID: id,
            Salary: value
        };
        $.ajax({
            url: '/Home/update',
            type: 'POST',
            dataType: 'Json',
            data: { model: JSON.stringify(data) },
            success: function (response) {
                if (response.status) {
                    alert('Update Successed.');
                }
                else {
                    alert('Update Failed');
                }
            }
        })
    },
    loadData: function () {
        $.ajax({
            url: '/Home/LoadData',
            type: 'GET',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.ID,
                            Name: item.Name,
                            Salary: item.Salary,
                            Status: item.Status == true ? "<span class=\"label label-success\">Actived</span>": "<span class=\"label label-danger\">Locked</span>"
                        });
                    });
                    $('#tblData').html(html);
                    homeController.paging(response.total, function () {
                        homeController.loadData();
                    });
                    homeController.registerEvent();
                }
            }
        })
    },
    paging: function (totalRow, callback) {
        var totalPage = Math.ceil(totalRow / homeConfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 10,
            onPageClick: function (event, page) {
                homeConfig.pageIndex = page;
                setTimeout(callback,200)
            }
        });
    }
}
homeController.init();