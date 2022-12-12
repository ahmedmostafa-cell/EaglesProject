using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class adids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LogisticCompanyId",
                table: "TransactionLogisticCompany",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TurkeyTwoId",
                table: "TransactionLogisticCompany",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LogisticCompanyId",
                table: "TbTransactionTurkeyTwo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TurkeyTwoId",
                table: "TbTransactionTurkeyTwo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LogisticCompanyId",
                table: "TbTransactionTurkeyOne",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TurkeyTwoId",
                table: "TbTransactionTurkeyOne",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LogisticCompanyId",
                table: "TbTransactionAbdo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TurkeyTwoId",
                table: "TbTransactionAbdo",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogisticCompanyId",
                table: "TransactionLogisticCompany");

            migrationBuilder.DropColumn(
                name: "TurkeyTwoId",
                table: "TransactionLogisticCompany");

            migrationBuilder.DropColumn(
                name: "LogisticCompanyId",
                table: "TbTransactionTurkeyTwo");

            migrationBuilder.DropColumn(
                name: "TurkeyTwoId",
                table: "TbTransactionTurkeyTwo");

            migrationBuilder.DropColumn(
                name: "LogisticCompanyId",
                table: "TbTransactionTurkeyOne");

            migrationBuilder.DropColumn(
                name: "TurkeyTwoId",
                table: "TbTransactionTurkeyOne");

            migrationBuilder.DropColumn(
                name: "LogisticCompanyId",
                table: "TbTransactionAbdo");

            migrationBuilder.DropColumn(
                name: "TurkeyTwoId",
                table: "TbTransactionAbdo");
        }
    }
}
