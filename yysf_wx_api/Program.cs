using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using yysf_Entity.BusEntitys;
using yysf_Entity_Framework;
using yysf_Repository;
using yysf_Repository.BusRepository;
using yysf_Repository.BusRepository.IBusRepository;
using yysf_Service.BusService;
using yysf_Service.IService.IBusService;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration= builder.Configuration;//获取配置文件
// Add services to the container.
//WebApi项目配置
builder.Services.AddDbContext<SqlDbContext>(optionsAction: options =>
{
    options.UseSqlServer(connectionString: configuration.GetConnectionString(name: "strConn"));
});
//依赖注入配置
builder.Services.AddScoped<IPictureRepository,PictureRepository>();//图片仓库
builder.Services.AddScoped < IBaseRepository<Classify>, BaseRepository<Classify>>();//文章分类仓库
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();//文章仓库
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//业务注入
builder.Services.AddScoped<IClassifyServeice, ClassifyService>();//分类业务
builder.Services.AddScoped<IArticleService, ArticleService > ();//文章业务


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
