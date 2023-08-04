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
ConfigurationManager configuration= builder.Configuration;//��ȡ�����ļ�
// Add services to the container.
//WebApi��Ŀ����
builder.Services.AddDbContext<SqlDbContext>(optionsAction: options =>
{
    options.UseSqlServer(connectionString: configuration.GetConnectionString(name: "strConn"));
});
//����ע������
builder.Services.AddScoped<IPictureRepository,PictureRepository>();//ͼƬ�ֿ�
builder.Services.AddScoped < IBaseRepository<Classify>, BaseRepository<Classify>>();//���·���ֿ�
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();//���²ֿ�
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ҵ��ע��
builder.Services.AddScoped<IClassifyServeice, ClassifyService>();//����ҵ��
builder.Services.AddScoped<IArticleService, ArticleService > ();//����ҵ��


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
