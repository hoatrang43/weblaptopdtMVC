/// <reference path="../../../../scripts/angular.min.js" />

var homeapp = angular.module("AdminApp", []);
homeapp.controller("LoginController", function ($rootScope, $window, $http) {
   
    $rootScope.Users = null;
    $rootScope.UN = "";
    $rootScope.PW = "";
    $rootScope.quyenad = "";
    $rootScope.quyenus = "";
    $rootScope.role = "";
   
  
    $rootScope.Login = function (us, pw) {
        $http({
            method: 'post',
            url: '/Areas/Login/Login',
            params: { us: us, pw: pw },
        }).then(function success(d) {
            if (d.data == null) {
                alert("tài khoản người dùng không đúng");
                $rootScope.UN = "";
                $rootScope.PW = "";
               
            }
            else {
              
                $rootScope.Users = d.data;
                if (d.data.Role == "admin") {    
                    $rootScope.role = d.data.Role;
                    $rootScope.quyenad = "";
                    $rootScope.quyenad = "KhongQuyen";
                }
                else {
                    $rootScope.role = d.data.Role;
                    $rootScope.quyenad = "KhongQuyen";
                    $rootScope.quyenus = "";
                }
                $window.location.href = '/Areas/Admin/Index';
            }
          
        }, function error(e) { });
    }


});
homeapp.run(function ($rootScope, $window, $http) {
    $rootScope.Logout2 = function () {

        $http.get('/Areas/Login/Logout').then(
            function (response) {
                $window.location.reload();
            },
            function (err) {
                alert(err);
            });
    };
})

homeapp.controller("ThongSoKyThuatController", function ($rootScope, $scope, $http, $window) {
    $http
        ({
            method: "get",
            url: "/CTSanPham/LayTSKT",
            params: { masp: localStorage.getItem("MaSP") }
        }).then(function Success(d) {

            $scope.TSKT = d.data;
        },
            function Error() {
                alert("Lấy TSKT lỗi");
            });
});

homeapp.controller("SanPhamController", function ($scope, $http, $rootScope) {
   

    $http({
        method: "get",
        url: "/Areas/Admin/GetLoai"
    }).then(function Success(d) {
        $scope.listLoai = d.data;
    },
        function error(e) {

        });

    $http({
        method: "get",
        url: "/Admin/GetTSKT"
    }).then(function Success(d) {
        $scope.TSKT = d.data;
    },
        function error(e) {
          
        });
    $rootScope.SelectSanPham = function (masp) {
        localStorage.setItem("MaSP", masp);
    }
    $http({
        method: 'get',
        url: '/Home/GetDong'
    }).then(function Success(d) {

        $rootScope.listDong = d.data;
    },
        function Error() {
            alert("Lấy Dòng SP lỗi");
        });
    $http({
        method: 'get',
        url: '/Home/GetThuongHieu'
    }).then(function Success(d) {

        $rootScope.listTH = d.data;
    },
        function Error() {
            alert("Lấy thương hiệu lỗi");
        });
    $scope.AddTH = function () {
        $scope.thuonghieu = null;
    };

    $scope.SaveAddTH = function () {
        alert("có vào")
        $http({
            method: 'post',
            url: '/SanPham/AddTH',
            data: JSON.stringify($scope.thuonghieu)
        }).then(function (d) {
            if (d.data == "") {
                $scope.listTH.push($scope.thuonghieu);
                $scope.thuonghieu= null;
                alert("Thêm thành công!");
            }
           
        }, function () {
            alert("Thêm lỗi");
        });
    }
     //$http({
    //    method: "get",
    //    url: "/SanPham/GetProduct"
    //}).then(function Success(d) {
    //    $scope.SanPhams = d.data;
    //},

    //    function error(e) {
    //        alert("Lấy sản phẩm lỗi");
    //    });

    $scope.Delete = function (s) {    
            $http({
                method: "Post",
                url: "/SanPham/DeleteSanPham1",
                data: { id: s.MaSP }
            }).then(function Success(d) {
                alert("Xóa thành công!");
                var vt = $scope.SanPhams.indexOf(s);
                $scope.SanPhams.splice(vt, 1);
                var v = $scope.TSKT.indexOf(s);
                $scope.TSKT.splice(v, 1);
                
            }, function error(e) {
                alert(" lỗi");
            });
        }
   
    //Phan trang vs tim kiem
    $scope.pageindex = sessionStorage.getItem('currentPage');
    if (sessionStorage.getItem('currentPage') == null) {
        $scope.pageindex = 1;
        $http({
            method: "get",
            url: '/SanPham/page/',
            params: { page: 1/*, pagesize: $scope.pagesize*/ }
        }).then(function success(d) {
            $scope.SanPhams = d.data;
           
        }, function (error) {
            alert("Lấy sản phẩm mới nhất lỗi");
        });
    } else {
      
        $http({
            method: "get",
            url: '/SanPham/page/',
            params: { page: $scope.pageindex/*, pagesize: $scope.pagesize*/ }
        }).then(function success(d) {
            $scope.SanPhams = d.data;         
        }, function (error) {
            alert("Lấy sản phẩm mới nhất lỗi");
        });
    }

    $scope.GetSanPhamListP = function () {
        $scope.pageindex = parseInt($scope.pageindex) + 1;
        sessionStorage.setItem('currentPage', $scope.pageindex);
        window.location = "/Areas/Admin/Index";
    }

    $scope.GetSanPhamListM = function () {
        $scope.pageindex = parseInt($scope.pageindex) - 1;
        sessionStorage.setItem('currentPage', $scope.pageindex);
        window.location = "/Areas/Admin/Index";
    }
    $scope.Add = function () {
        $scope.sanpham = null;
    };
    $scope.Edit = function (s) {
        $scope.sanpham = s;
    }
    $scope.SaveAdd = function () {
        $http({
            method: 'post',
            url: '/SanPham/AddSanPham',
            data: JSON.stringify($scope.sanpham)
        }).then(function (d) {
            if (d.data == "") {
                $scope.SanPhams.push($scope.sanpham);
                $scope.TSKT.push($scope.sanpham);
                $scope.sanpham = null;
                alert("Thêm thành công!");              
            }         
            else {
                alert("Thêm thành công")
            }
        }, function () {
                alert("Thêm lỗi");
        });
    }  
    $scope.SaveEdit = function () {
        $http({
            method: 'Post',
            datatype: 'Json',
            url: "/SanPham/EditSanPham1",
            data:  $scope.sanpham
        }).then(function (d) {
            if (d.data == "") {
                alert("Sửa thành công")
            }
            else
            {
                alert("Sửa thành công")
            }
        }, function () {
            alert("Lỗi");
        })
    };  

    $rootScope.SelectLoai = function (l) {
        localStorage.setItem("MaLoai", masp);
    }

    $scope.SelectSanPham = function (masp) {
        alert(masp);
        localStorage.setItem("MaSP", masp);

    }


    $http
        ({
            method: "get",
            url: "/CTSanPham/LayTSKT",
            params: { masp: localStorage.getItem("MaSP") }
        }).then(function Success(d) {

            $scope.TSKT = d.data;
        },
            function Error() {
                alert("Lấy TSKT lỗi");
            });

    $scope.UploadFiles = function (file, kieu) {
        $scope.SelectedFiles = file;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: 'SanPham/Upload',
                data: { masp: $scope.sanpham.MaSP, files: $scope.SelectedFiles }
            }).then(function (d) {
                if (kieu == "Anh")
                    $scope.sanpham.AnhTo = d.data[0];
                else
                    $scope.sanpham.AnhNho = d.data[0];
            }, function (error) {
                alert('upload lỗi');
            });
        }
    };


});
homeapp.controller("NhanVienController", function ($scope, $http, $rootScope) {
    $http({
        method: 'get',
        url: '/Areas/Admin/GetNhanVien'
    }).then(function Success(d) {

        $rootScope.listNV = d.data;
    },
        function Error() {
            alert("Lấy NV lỗi");
        });


    $scope.Delete = function (s) {
        $http({
            method: "Post",
            url: "/Areas/Admin/DeleteNhanVien",
            data: { id: s.MaNV }
        }).then(function Success(d) {
            var vt = $scope.listNV.indexOf(s);
            $scope.listNV.splice(vt, 1);
            alert("Xóa thành công!");
        }, function error(e) {
            alert("Lấy sản phẩm lỗi");
        });
    }

    $scope.Add = function () {
        $scope.sanpham = null;
    };
    $scope.Edit = function (s) {
        $scope.sanpham = s;
        console.log(s)

    }

    $scope.SaveAdd = function () {
        $http({
            method: 'post',
            url: '/SanPham/AddNhanVien',
            data: JSON.stringify($scope.sanpham)
        }).then(function (d) {
            if (d.data == "") {
                $scope.listNV.push($scope.sanpham);
                $scope.sanpham = null;
                alert("Thêm thành công!");
            }
            //else {
            //    alert(d.data);
            //}
        }, function () {
            alert("Thêm lỗi");
        });
    }
    $scope.SaveEdit = function () {
        $http({
            method: 'Post',
            datatype: 'Json',
            url: "/Areas/Admin/EditNhanVien",
            data: $scope.sanpham
        }).then(function (d) {
            if (d.data == "") {
                alert("Sửa thành công")
            }
            //else
            //{
            //    alert(d.data);
            //}
        }, function () {
            alert("Lỗi");
        })
    };



});

homeapp.controller("DongSPController", function ($scope, $http, $rootScope) {
    $http({
        method: 'get',
        url: '/Home/GetDong'
    }).then(function Success(d) {

        $rootScope.listDong = d.data;
    },
        function Error() {
            alert("Lấy Dòng SP lỗi");
        });


    $scope.Delete = function (s) {
        $http({
            method: "Post",
            url: "/SanPham/DeleteSanPham",
            data: { id: s.MaSP }
        }).then(function Success(d) {
            var vt = $scope.listDong.indexOf(s);
            $scope.listDong.splice(vt, 1);
            alert("Xóa thành công!");
        }, function error(e) {
            alert("Lấy sản phẩm lỗi");
        });
    }

    $scope.Add = function () {
        $scope.sanpham = null;
    };
    $scope.Edit = function (s) {
        $scope.sanpham = s;
        console.log(s)

    }

    $scope.SaveAdd = function () {
        $http({
            method: 'post',
            url: '/SanPham/AddSanPham',
            data: JSON.stringify($scope.sanpham)
        }).then(function (d) {
            if (d.data == "") {
                $scope.listDong.push($scope.sanpham);
                $scope.sanpham = null;
                alert("Thêm thành công!");
            }
            //else {
            //    alert(d.data);
            //}
        }, function () {
            alert("Thêm lỗi");
        });
    }
    $scope.SaveEdit = function () {
        $http({
            method: 'Post',
            datatype: 'Json',
            url: "/SanPham/EditSanPham",
            data: $scope.sanpham
        }).then(function (d) {
            if (d.data == "") {
                alert("Sửa thành công")
            }
        }, function () {
            alert("Lỗi");
        })
    }; 

   
});