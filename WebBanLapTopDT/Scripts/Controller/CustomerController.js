/// <reference path="../angular.min.js" />
var homeapp = angular.module("CustomerApp", ['angularUtils.directives.dirPagination']);



homeapp.controller("MenuController",
    function ($scope, $rootScope, $http) {
        $http({
            method: 'get',
            url: '/Home/GetCategory'
        }).then(function Success(d) {

            $rootScope.listLoai = d.data;
        },
            function Error() {
                alert("Lấy loại sản phẩm lỗi");
            });
        $scope.SelectLoai = function (l) {
            localStorage.setItem("MaLoai", l);
        }
        $http({
            method: 'get',
            url: '/Home/GetThuongHieu'
        }).then(function Success(d) {

            $rootScope.listTH = d.data;
        },
            function Error() {
                alert("Lấy thương hiệu lỗi");
            });
        $scope.SelectTH = function (l) {
            localStorage.setItem("MaThuongHieu", l);
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

        $scope.SelectDong = function (l) {
            localStorage.setItem("MaDong", l);
        }
    }

);



homeapp.controller("SanPhamController", function ($scope, $http, $rootScope) {
  
    $scope.sortcolumn = "MaSP";
    $scope.reverse = true;
    $scope.direct = "Ascending";
    $scope.Chon = function (d) {
        if ($scope.direct == "Ascending") {
            $scope.reverse = false;
            $scope.direct = "Decreasing";
        } else {
            $scope.reverse = true;
            $scope.direct = "Ascending";
        }
    }
    //$http.get('/SanPham/GetProduct').then(function (d) {
    //    $scope.ListSanPham = d.data;
    //}, function (error) { alert('That bai'); });

    $http({
        method: "get",
        url: "/SanPham/GetProduct"
    }).then(function Success(d) {
        $scope.ListSanPham = d.data;
    },

        function error(e) {
            alert("Lấy sản phẩm lỗi");
        });

    $scope.SelectSanPham = function (masp) {
        localStorage.setItem("MaSP", masp);
    }

    // chọn sản phẩm đưa vào giỏ hàng
    $rootScope.AddCart = function (s) {
        $http({
            method: 'post',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: { sp: s }
        }).then(function success(d) {
            $http({
                method: 'get',
                datatype: 'json',
                url: '/GioHang/GetCart',
            }).then(function success(d) {
                $rootScope.dsDonHang = d.data.DSDONHANG;
                $rootScope.SL = d.data.SoLuong;
                $rootScope.Tong = d.data.ThanhTien;
                if ($rootScope.dsDonHang.lenght > 0) {
                    $scope.Het = "false";
                }
                else { $scope.Het = "true"; }
                alert("Thêm vào giỏ hàng thành công!");
            }, function error(e) {
                alert('Gio hang loi');
            });
            //if (d.status) {
            //    $window.location.href = "/DatHang/Index";
            //}        
        }, function () { alert('Lỗi'); })
    }

});
homeapp.controller("SearchController", function ($scope, $http, $window, $rootScope) {
    //$rootScope.searchName = "";
    ////var tensp = localStorage.getItem("TenSP");
    //$scope.Search = function (tensp) {
    //    alert(tensp);
    //    $http({
    //        method: "get",
    //        url: "/SanPham/TimKiemTheoTen",
    //        params: { tensp: tensp}
    //    }).then(function Success(d) {
    //        $window.location.href = "/SanPham/Search";
    //        $scope.ListSanPham = d.data;
    //    },
    //        function error(e) {
    //            alert("Lấy sản phẩm lỗi");
    //        });

    //}
    $rootScope.Search = function (str) {
        alert(str);
        $http({
            method: "get", datatype: "Json", url: '/SanPham/Search1', params: { ma: str }
        }).then(function (d) {
          
            $rootScope.listSanPham = d.data;
        });
    }
       
    
});

homeapp.controller("SanPhamController1", function ($rootScope, $scope, $http, $window) {
    //Begin sort
    $rootScope.sortcolumn = "MaSP";
    $rootScope.reverse = true;
    $rootScope.direct = "Ascending";
  
    //Khi nhấn button sẽ chuyển đổi chiều sắp xếp
    $rootScope.Chon = function (d) {
        if ($rootScope.direct == "Ascending") {
            $rootScope.reverse = false;
            $rootScope.direct = "Decreasing";
        }
        else {
            $rootScope.reverse = true;
            $rootScope.direct = "Ascending";
        }
    }; 


    //DSSP BÁN CHẠY
    $http({
        method: "get",
        url: "/SanPham/GetDSSPBanChay"
    }).then(function Success(d) {
        $scope.SPBanChay = d.data;
    },

        function error(e) {
            alert("Lấy sản phẩm lỗi");
        });
    //DSSP MỚI
    $http({
        method: "get",
        url: "/SanPham/LayDSSPMoi",
    }).then(function Success(d) {
        $scope.SanPhamMoi = d.data;
    },

        function error(e) {
            alert("Lấy sản phẩm lỗi");
        });

    //DSSP Theo dòng
    var madong = localStorage.getItem("MaDong");
    $http({
        method: "get",
        url: "/SanPham/LayDSSPTheoDong",
        params: { madong: madong }
    }).then(function Success(d) {
        $scope.lstDong = d.data;
    }, function error(e) {
        alert("Lấy sản phẩm lỗi");
    });
    //DSSP theo thương hiệu
    var maTH = localStorage.getItem("MaThuongHieu");
    $http({
        method: "get",
        url: "/SanPham/LayDSSPThuongHieu",
        params: { maTH: maTH }
    }).then(function Success(d) {
        $scope.lstTH = d.data;
    }, function error(e) {
        alert("Lấy sản phẩm lỗi");
    });
    //DSSP theo loại
    var maloai = localStorage.getItem("MaLoai");
    $http({
        method: "get",
        url: "/SanPham/LayDSSPTheoLoai",
        params: { maloai: maloai }
    }).then(function Success(d) {
        $scope.lstLoai = d.data;
    }, function error(e) {
        alert("Lấy sản phẩm lỗi");
    });

    //Phan trang vs tim kiem
    $scope.pageindex = sessionStorage.getItem('currentPage');
    if (sessionStorage.getItem('currentPage') == null) {
        $scope.pageindex = 1;
        $http({
            method: "get",
            url: '/SanPham/page/',
            params: { page: 1/*, pagesize: $scope.pagesize*/ }
        }).then(function success(d) {
            $scope.products_by_date = d.data;
            //sessionStorage.setItem('currentPage', $scope.pageindex);
            //window.location = "newest?page=" + $scope.pageindex + "";
        }, function (error) {
            alert("Lấy sản phẩm mới nhất lỗi");
        });
    } else {
        //$scope.pageindex = parseInt($scope.pageindex) + 1;
        $http({
            method: "get",
            url: '/SanPham/page/',
            params: { page: $scope.pageindex/*, pagesize: $scope.pagesize*/ }
        }).then(function success(d) {
            $scope.products_by_date = d.data;
            //sessionStorage.setItem('currentPage', $scope.pageindex);
            //window.location = "newest?page=" + $scope.pageindex + "";
        }, function (error) {
            alert("Lấy sản phẩm mới nhất lỗi");
        });
    }

    $scope.GetSanPhamListP = function () {
        $scope.pageindex = parseInt($scope.pageindex) + 1;
        sessionStorage.setItem('currentPage', $scope.pageindex);
        window.location = "/Home/Index";
    }

    $scope.GetSanPhamListM = function () {

        $scope.pageindex = parseInt($scope.pageindex) - 1;
        sessionStorage.setItem('currentPage', $scope.pageindex);
        window.location = "/Home/Index";
    }
  
    $rootScope.SelectSanPham = function (masp) {
        localStorage.setItem("MaSP", masp);      
    }
   
   // chọn sản phẩm đưa vào giỏ hàng
    $rootScope.AddCart = function (s) {
        $http({
            method: 'post',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: { sp: s }
        }).then(function success(d) {
            $http({
                method: 'get',
                datatype: 'json',
                url: '/GioHang/GetCart',
            }).then(function success(d) {
                $rootScope.dsDonHang = d.data.DSDONHANG;
                $rootScope.SL = d.data.SoLuong;
                $rootScope.Tong = d.data.ThanhTien;
                if ($rootScope.dsDonHang.lenght > 0) {
                    $scope.Het = "false";
                }
                else { $scope.Het = "true"; }
                alert("Thêm vào giỏ hàng thành công!");
            }, function error(e) {
                alert('Gio hang loi');
            });     
        }, function () { alert('Lỗi'); })
    }
});
homeapp.controller("ChiTietConTroller", function ($rootScope, $scope, $http, $window) {

    $http
        ({
            method: "get",
            url: "/CTSanPham/GetCTSP",
            params: { ProID: localStorage.getItem("MaSP") }
        }).then(function Success(d) {

            $scope.Product = d.data;
        },
            function Error() {
                alert("Lấy sản phẩm lỗi");
            });
   
});
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

homeapp.controller("DangKiController", function ($rootScope, $scope, $http, $window) {
       $http({
        method: "get",
        url: "/Home/LayDSKH"
    }).then(function Success(d) {
        $scope.KhachHangs = d.data;
    },
        function error(e) {
            alert("Lấy lỗi");
        });

    $scope.Add = function()
    {
        $scope.khachhang = null;
    };

    $scope.Save = function () {
        $http({
            method: 'post',
            url: '/Home/DangKi',
            data: JSON.stringify($scope.khachhang)
        }).then(function (d) {
            if (d.data == "") {
                $scope.KhachHangs.push($scope.khachhang);              
                $scope.khachhang = null;           
            }
            else {
                alert("Đăng kí  thành công")
            $window.location.href = "/Home/Index";
            }
        }, function () {
            alert("Thêm lỗi");
        });
    }  
});

homeapp.controller("LoginController", function ($rootScope, $scope, $http, $window) {  
    $rootScope.close = "";
    $rootScope.Khach = null;
    $rootScope.login = 0;
    $rootScope.login_state = "Đăng Nhập";
    if (sessionStorage.getItem("username") == null) {
        $rootScope.login_state = "Đăng Nhập";
    }
    else {
        $rootScope.login_state = "Đăng Xuất";
    }
    $rootScope.Username = sessionStorage.getItem("username");
    $rootScope.remember = false;
    $rootScope.Login = function (un, pw, rp) {
        $http({
            url: '/Home/Login',
            method: 'get',
            params: {
                un: un,
                pw: pw,
                rp: rp
            }
        }).then(function success(d) {
            if (d.data.login == "0")//đăng nhập ko thành công
            {
                $rootScope.close = "";
                $rootScope.login = d.data.login;
                alert("Tài khoản không đúng, yêu cầu nhập lại");

            }
            else // đăng nhập thành công, đóng giao diện đăng nhập
            {
                $rootScope.login = d.data.login;
                $rootScope.Username = d.data.khach.Username;
                sessionStorage.setItem("username", d.data.khach.Username); //lưu username vào session
                $rootScope.login_state = "Đăng Xuất";
                $rootScope.close = 'modal';
                alert('Đăng nhập thành công');
            }
        }, function error(e) { });
    }
   

    $rootScope.Logout = function () {
        $http.get('/Home/Logout').then(function (d) {
            $rootScope.Log = "Login";
            $rootScope.login_state = "Đăng nhập";
            $rootScope.Log = "Login";
            sessionStorage.removeItem("username");
        }, function () { });
    }
});
homeapp.controller("CartController", function ($window, $scope, $rootScope, $http) {
    $rootScope.DangNhap = "";
    $rootScope.DatHang = "";
    $rootScope.SoLuong = 0;
    $rootScope.Log = "Login";
    $rootScope.KhachHang = "";

    $rootScope.TinhTong = function () {
        $rootScope.Tong = 0;
        $rootScope.dsDonHang.forEach((item) => {
            $rootScope.Tong += item.DonGia * item.SoLuong
        })
    }
    $rootScope.TongSL = function () {
        $rootScope.TongSL= 0;
        $rootScope.dsDonHang.forEach((item) => {
            $rootScope.SL += item.SoLuong
        })
    }
    // Lấy về các sản phẩm trong giỏ hàng lên giao diện
    $http({
        method: 'get',
        datatype: 'json',
        url: '/GioHang/GetCart',
    }).then(function success(data) {
        $rootScope.dsDonHang = data.data.DSDONHANG;
        $rootScope.SL = data.data.SoLuong;
        $rootScope.Tong = data.data.ThanhTien;
        if ($rootScope.dsDonHang.lenght > 0) {
            $scope.Het = "false";
        }
        else { $scope.Het = "true"; }
       
    }, function error(e) {
        alert('Gio hang loi');
    });

    //xoa san pham trong gio hang
    $scope.Delete = function (masp) {
        $http({
            method: "get",
            url: '/GioHang/XoaSP',
            datatype: 'json',
            params: { masp: masp }
        }).then(function (d) {
            location.reload();
        }, function (error) {
            alert('Xoa san pham khoi gio hang loi');
        })
    }

    $scope.ContinueShopping = function () {
        $window.history.back();// quay lại trang trc
    }
    $rootScope.KiemTraDangNhap = function () {
        $http.get('/DatHang/ReadCustomer').then(
            function (d) {
                if (d.data.login == "1")//đã đăng nhập thì hiển thị giao diện đặt hàng
                {
                    $rootScope.DangNhap = "";
                    $rootScope.KhachHang = d.data.khach;
                    console.log(JSON.stringify($rootScope.khach));
                    $http.get('/GioHang/GetCart').then(function (d) {
                        $rootScope.dsDonHang = d.data.DSDONHANG;
                        $rootScope.SL= d.data.SoLuong;
                        $rootScope.Tong = d.data.ThanhTien;
                    }, function (e) { });
                    $window.location.href = '/DatHang/Index';
                }
                else //hiện thị giao diện đăng nhập
                {
                   
                    $rootScope.DangNhap = '#Login'; //thiết lập hiển thị modal đăng nhập
                }
            }, function error(e) {
                alert("Lỗi");
        });
    }
});
homeapp.controller("DatHangController", function ($scope, $rootScope, $http, $window) {
    $rootScope.KhachHang = null;
    $http.get('/DatHang/GetCustomer').then(
        function (d) {
            $rootScope.KhachHang = d.data.khach;
        },
        function () {
            alert("Lấy khách hàng lỗi");
        }
    )
    $http({
        method: 'get',
        datatype: 'json',
        url: '/GioHang/GetCart',
    }).then(function success(data) {
        $rootScope.dsDonHang = data.data.DSDONHANG;
        $rootScope.SL = data.data.SoLuong;
        $rootScope.Tong = data.data.ThanhTien;
        if ($rootScope.dsDonHang.lenght > 0) {
            $scope.Het = "false";
        }
        else { $scope.Het = "true"; }

    }, function error(e) {
        alert('Gio hang loi');
    });
    $rootScope.TinhTong = function () {
        $rootScope.Tong = 0;
        $rootScope.dsDonHang.forEach((item) => {
            $rootScope.Tong += item.DonGia * item.SoLuong
        })
    }
    $scope.DatHang = function () {   
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/DatHang/DatHang',
            params: {
                khachhang: JSON.stringify($rootScope.KhachHang),
                tong: JSON.stringify($rootScope.Tong),
               data: JSON.stringify($rootScope.dsDonHang)
            }
        }).then(function (d) {
            $window.location.href = "/DatHang/ThongBao"; 
        }, function () {
                alert("Lỗi");
        })
    }
});
