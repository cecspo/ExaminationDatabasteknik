using Data.Entities;

namespace Data.Tests.SeedData;

public static class TestData
{
    public static readonly ServiceEntity[] ServiceTestData =
    [
    new ServiceEntity {Id = 1, ServiceName = "Konsulttjänst"},
        new ServiceEntity {Id = 2, ServiceName = "Utbildning"},
        new ServiceEntity {Id = 3, ServiceName = "Support"}
    ];

    public static readonly StatusCodeEntity[] StatusCodeTestData =
    [
        new StatusCodeEntity {Id = 1, StatusCodeName = "Ej påbörjad"},
        new StatusCodeEntity {Id = 2, StatusCodeName = "Pågår"},
        new StatusCodeEntity {Id = 3, StatusCodeName = "Avslutad"}
    ];

    public static readonly BranchTypeEntity[] BranchTypeTestData =
    [
        new BranchTypeEntity {Id = 1, BranchTypeName = "IT"},
        new BranchTypeEntity {Id = 2, BranchTypeName = "Ekonomi"},
        new BranchTypeEntity {Id = 3, BranchTypeName = "Hälsa"}
    ];

    public static readonly CustomerTypeEntity[] CustomerTypeTestData =
[
    new CustomerTypeEntity {Id = 1, CustomerTypeName = "Privatperson"},
        new CustomerTypeEntity {Id = 2, CustomerTypeName = "Företag"},
        new CustomerTypeEntity {Id = 3, CustomerTypeName = "Organisation"}
];

    public static readonly CustomerContactEntity[] CustomerContactTestData =
    [
        new CustomerContactEntity {Id = 1, FirstName = "Casper", LastName = "Haglund Sporrong", Email = "casp@domain.com" },
        new CustomerContactEntity {Id = 2, FirstName = "Peder", LastName = "Haglund", Email = "peder@domain.com" },
        new CustomerContactEntity {Id = 3, FirstName = "Gunilla", LastName = "Haglund G Sporrong", Email = "ggs@domain.com" },
    ];

    public static readonly PostalCodeEntity[] PostalCodeTestData =
    [
        new PostalCodeEntity {Id = 1, PostalCode = "12345", City = "Stockholm"},
        new PostalCodeEntity {Id = 2, PostalCode = "54321", City = "Göteborg"},
        new PostalCodeEntity {Id = 3, PostalCode = "67890", City = "Malmö"}
    ];

    public static readonly PaymentEntity[] PaymentTestData =
    [
        new PaymentEntity {Id = 1, PaymentMethod = "Faktura", PayedAt = new DateTime(2021, 12, 30)},
        new PaymentEntity {Id = 2, PaymentMethod = "Kreditkort", PayedAt = new DateTime(2021, 12, 30)},
        new PaymentEntity {Id = 3, PaymentMethod = "Swish", PayedAt = new DateTime(2021, 12, 30)}
    ];

    public static readonly EmployeeEntity[] EmployeeTestData =
    [
        new EmployeeEntity {Id = 1, FirstName = "Anton", LastName = "Haglund", Email = "anton@domain.com", StartedAt = new DateOnly(2001, 10, 05)},
        new EmployeeEntity {Id = 2, FirstName = "Cecilia", LastName = "Sporrong", Email = "ccf@domain.com", StartedAt = new DateOnly(2010, 03, 16)},
        new EmployeeEntity {Id = 3, FirstName = "Céline", LastName = "Haglund Sporrong", Email = "cello@domain.com", StartedAt = new DateOnly(2011, 01, 22)}
    ];

    public static readonly TaskEntity[] TaskTestData =
    [
        new TaskEntity {Id = 1, Task = "Uppdatera listor"},
        new TaskEntity {Id = 2, Task = "Skicka faktura"},
        new TaskEntity {Id = 3, Task = "Registrera utgifter"}
    ];

    public static readonly AddressEntity[] AddressTestData =
    [
        new AddressEntity {Id = 1, StreetName = "Storgatan 1", PostalCodeId = PostalCodeTestData[1].Id},
        new AddressEntity {Id = 2, StreetName = "Lillgatan 2", PostalCodeId = PostalCodeTestData[2].Id},
        new AddressEntity {Id = 3, StreetName = "Mellangatan 3", PostalCodeId = PostalCodeTestData[0].Id}
    ];

    public static readonly CustomerEntity[] CustomerTestData =
    [
        new CustomerEntity {
            Id = 1,
            CustomerName = "IKEA",
            CustomerContactId = CustomerContactTestData[1].Id,
            CustomerTypeId = CustomerTypeTestData[1].Id,
            BranchTypeId = BranchTypeTestData[1].Id,
        },
        new CustomerEntity {
            Id = 2,
            CustomerName = "Nackademin AB",
            CustomerContactId = CustomerContactTestData[2].Id,
            CustomerTypeId = CustomerTypeTestData[2].Id,
            BranchTypeId = BranchTypeTestData[2].Id,
        },
        new CustomerEntity {
            Id = 3,
            CustomerName = "Ekofront AB",
            CustomerContactId = CustomerContactTestData[0].Id,
            CustomerTypeId = CustomerTypeTestData[0].Id,
            BranchTypeId = BranchTypeTestData[0].Id,
        }
    ];

    public static readonly ProjectManagerEntity[] ProjectManagerTestData =
    [
        new ProjectManagerEntity {Id = 1, EmployeeId = EmployeeTestData[0].Id},
        new ProjectManagerEntity {Id = 2, EmployeeId = EmployeeTestData[1].Id}, 
        new ProjectManagerEntity {Id = 3, EmployeeId = EmployeeTestData[2].Id}
    ];
    
    public static readonly ProjectEntity[] ProjectTestData =
    [
         new ProjectEntity {
            ProjectNumber = 1,
            ProjectName = "Databasteknik",
            Notes = "Kurs i databasteknik",
            StartDate = new DateTime(2025, 02, 03), EndDate = new DateTime(2025, 10, 03),
            CustomerId = CustomerTestData![1].Id,
            ProjectManagerId = ProjectManagerTestData![1].Id,
            StatusCodeId = StatusCodeTestData[1].Id,
            ServiceId = ServiceTestData[1].Id,
        },
        new ProjectEntity {
            ProjectNumber = 2,
            ProjectName = "Frontend 1",
            Notes = "Kurs i Frontend",
            StartDate = new DateTime(2024, 02, 03), EndDate = new DateTime(2025, 02, 03),
            CustomerId = CustomerTestData[2].Id,
            ProjectManagerId = ProjectManagerTestData[2].Id,
            StatusCodeId = StatusCodeTestData[2].Id,
            ServiceId = ServiceTestData[2].Id,
        },
        new ProjectEntity {
            ProjectNumber = 3,
            ProjectName = "Frontend 2",
            Notes = "Kurs i Frontend",
            StartDate = new DateTime(2022, 02, 03), EndDate = new DateTime(2026, 02, 03),
            CustomerId = CustomerTestData[0].Id,
            ProjectManagerId = ProjectManagerTestData[0].Id,
            StatusCodeId = StatusCodeTestData[0].Id,
            ServiceId = ServiceTestData[0].Id,
        }
     ];

    public static readonly ProjectCommentEntity[] ProjectCommentTestData =
    [
        new ProjectCommentEntity {
            Id = 1, CommentText = "Bra jobbat!",
            CreatedAt = new DateTime(2022, 10, 29),
            ProjectId = ProjectTestData![1].ProjectNumber,
            EmployeeId = EmployeeTestData[1].Id
            },
        new ProjectCommentEntity {
            Id = 2, CommentText = "Du behöver göra om!",
            CreatedAt = new DateTime(2022, 10, 29),
            ProjectId = ProjectTestData![2].ProjectNumber,
            EmployeeId = EmployeeTestData[2].Id
            },
        new ProjectCommentEntity {
            Id = 3, CommentText = "Det här behövs inte!",
            CreatedAt = new DateTime(2022, 10, 29),
            ProjectId = ProjectTestData![0].ProjectNumber,
            EmployeeId = EmployeeTestData[0].Id
            }
    ];

    public static readonly ProjectDocumentEntity[] ProjectDocumentTestData =
    [
        new ProjectDocumentEntity {
            Id = 1, DocumentName = "Projektplan",
            FilePath = "C:\\Projects\\Databasteknik1",
            UpdatedAt = new DateTime(2022, 10, 29),
            ProjectId = ProjectTestData![1].ProjectNumber,
            EmployeeId = EmployeeTestData[1].Id
            },
        new ProjectDocumentEntity {
            Id = 2, DocumentName = "Tidsrapport",
            FilePath = "C:\\Projects\\Databasteknik2",
            UpdatedAt = new DateTime(2022, 10, 29),
            ProjectId = ProjectTestData![2].ProjectNumber,
            EmployeeId = EmployeeTestData[2].Id
            },
        new ProjectDocumentEntity {
            Id = 3, DocumentName = "Faktura",
            FilePath = "C:\\Projects\\Databasteknik3",
            UpdatedAt = new DateTime(2022, 10, 29),
            ProjectId = ProjectTestData![0].ProjectNumber,
            EmployeeId = EmployeeTestData[0].Id
            }
    ];
}
