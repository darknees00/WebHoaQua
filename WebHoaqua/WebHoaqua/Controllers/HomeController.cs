using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using WebHoaqua.AddCart;
using WebHoaqua.Entity;
using WebHoaqua.Models;

namespace WebHoaqua.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FruitShopContext _context;
        public INotyfService _notyfService { get; }
        public HomeController(ILogger<HomeController> logger, FruitShopContext context, INotyfService notyfService)
        {
            _context = context;
            _logger = logger;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            var lsDanhsach = _context.Products.AsNoTracking().ToList();
            var top1 = _context.Products.AsNoTracking().Take(1).OrderByDescending(x => x.ProductId).FirstOrDefault();
            var top5 = _context.Products.AsNoTracking().OrderByDescending(x => x.ProductId).Take(5).ToList();
            var danhmuc = _context.Categories.AsNoTracking().ToList();
            var lsSanpham1 = _context.Products.AsNoTracking().Where(x => x.CategoryId == 1).ToList();

            ViewBag.top1s = top1;
            ViewBag.top5s = top5;
            ViewBag.danhmucs = danhmuc;
            ViewBag.lsSanpham1s = lsSanpham1;
            return View(lsDanhsach);
        }

        [Route("/{ProductName}-{ProductId}.html", Name = "details")]
        public IActionResult detailss(int ProductId)
        {
            var sanpham = _context.Products.AsNoTracking().FirstOrDefault(x => x.ProductId == ProductId);
            return View(sanpham);
        }

        public IActionResult Cart()
        {
            return View(listCart());
        }

        public IActionResult thanhtoan()
        {
            //Đầu tiên, cần lấy cookie của người dùng bằng cách sử dụng đối tượng HttpContext như sau:
            //var cookie = HttpContext.Request.Cookies[CookieAuthenticationDefaults.AuthenticationScheme];

            //// Tiếp theo, bạn cần giải mã cookie thành đối tượng ClaimsPrincipal để lấy thông tin người dùng bằng cách sử dụng phương thức AuthenticationHttpContextExtensions.AuthenticateAsync của đối tượng HttpContext như sau:
            //var giaima = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //var principal = HttpContext.User as ClaimsPrincipal;
            //var ids = principal.Identity.Name;
            //int id1 = int.Parse(ids.ToString());

            //string userId = HttpContext.User.FindFirstValue(ClaimTypes.Role); // Lấy ra quyền của người dùng
            string userId = HttpContext.User.FindFirstValue("UserId");
            if (userId != null)
            {
                // Lấy thông tin trong giỏ hàng
                var lsCart = HttpContext.Session.Get<List<Cart>>("giohang");
                Order oders = new Order();
                // Gán dữ liệu cho bảng "Order"
                oders.Ten = "Don hang - " + DateTime.Now.ToString("yyyyMMddHHmmss");
                oders.Statuc = 1;
                oders.UsersId = userId;
                oders.Ngaytao = DateTime.Now;
                _context.Orders.Add(oders);
                // Lưu thông tin vào bảng "Order"
                _context.SaveChanges();

                // Lấy ra "id" của bảng "Order" vừa mới tạo để lưu vào bảng "OrderDetails"
                var order_id = oders.Id;

                List<OrderDetai> lsOrderDetail = new List<OrderDetai>();
                foreach (var item in lsCart)
                {
                    OrderDetai orderdetail = new OrderDetai();
                    orderdetail.Soluong = item.soluong;
                    orderdetail.OrderId = order_id;
                    orderdetail.Tongtien = (int)item.tonggia; // Ép kiểu sang "int". Vì "item.tonggia" là kiểu float còn "orderdetail.Tongtien" là kiểu int, nên phải ép kiểu từ float sang int để lưu vào database
                    orderdetail.SanphamId = item.Mahh;
                    lsOrderDetail.Add(orderdetail); // Lưu dữ liệu vừa thêm vào List(lsOrderDetail)
                }

                _context.OrderDetais.AddRange(lsOrderDetail);
                _context.SaveChanges();
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        public List<Cart> listCart()
        {
            var cart = HttpContext.Session.Get<List<Cart>>("giohang");
            if (cart == null)
            {
                cart = new List<Cart>();
            }
            return cart;
        }

        [HttpPost]
        [Route("/api/AddToCart")]
        public IActionResult AddToCart(int id)
        {
            var lsCart = listCart();
            var myCart = lsCart.SingleOrDefault(x => x.Mahh == id);
            if (myCart == null)
            {
                var sanphams = _context.Products.SingleOrDefault(x => x.ProductId == id);
                myCart = new Cart
                {
                    Mahh = id,
                    tieude = sanphams.ProductName,
                    hinhanh = sanphams.Image,
                    gia = sanphams.PriceSale.Value,
                    soluong = 1
                };
                lsCart.Add(myCart);
                _notyfService.Success("Add Giỏ hàng thành công");
            }
            else
            {
                myCart.soluong += 1;
                _notyfService.Success("Cập nhật Giỏ hàng thành công");
            }
            HttpContext.Session.Set("giohang", lsCart);
            return RedirectToAction("Index");
        }

        [Route("/theloai/{CateId}", Name = "theloais")]
        public IActionResult theloai(int CateId)
        {
            var theloaiOne = _context.Categories.AsNoTracking().SingleOrDefault(x => x.CateId== CateId);
            var lsTheLoai = _context.Categories.AsNoTracking().ToList();
            var lsDanhsachTop1 = _context.Products.AsNoTracking().Where(x => x.CategoryId == theloaiOne.CateId).OrderByDescending(x => x.ProductId).Take(3).ToList();
            var lsDanhsach = _context.Products.AsNoTracking().Where(x => x.CategoryId == theloaiOne.CateId).ToList();

            ViewBag.lsTheLoais = lsTheLoai;
            ViewBag.theloaiOnes = theloaiOne;
            ViewBag.lsDanhsachTop1 = lsDanhsachTop1;

            return View(lsDanhsach);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Pgae()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}