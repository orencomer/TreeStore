using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeStore.Data.Migrations
{
    public partial class mycampings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Campaigns_CampaignId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCampaigns_Campaigns_CampaignId",
                table: "CategoryCampaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCampaigns_Campaigns_CampaignId",
                table: "ProductCampaigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns");

            migrationBuilder.RenameTable(
                name: "Campaigns",
                newName: "Campaign");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Campaign_CampaignId",
                table: "Categories",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCampaigns_Campaign_CampaignId",
                table: "CategoryCampaigns",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCampaigns_Campaign_CampaignId",
                table: "ProductCampaigns",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Campaign_CampaignId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCampaigns_Campaign_CampaignId",
                table: "CategoryCampaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCampaigns_Campaign_CampaignId",
                table: "ProductCampaigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign");

            migrationBuilder.RenameTable(
                name: "Campaign",
                newName: "Campaigns");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Campaigns_CampaignId",
                table: "Categories",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCampaigns_Campaigns_CampaignId",
                table: "CategoryCampaigns",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCampaigns_Campaigns_CampaignId",
                table: "ProductCampaigns",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
