﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "5%" },
            { "data": "creationDate", "width": "5%" },
            { "data": "startDate", "width": "5%" },
            { "data": "durationInDays", "width": "5%" },
            { "data": "userId", "width": "5%" },
            { "data": "price", "width": "5%" },
            { "data": "category.name", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `

                <a  href="/Admin/Product/Upsert?id=${data}" class="btn btn-secondary" > <i class="bi bi-pencil-square"></i> </br> Edit</a>
                `
                },
                "width": "5%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                <a onclick="Delete('/Admin/Product/Delete/${data}')" class="btn btn-danger"><i class="bi bi-trash3"></i> &nbsp; Delete</a>
                `
                },
                "width": "5%"
            },
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}     