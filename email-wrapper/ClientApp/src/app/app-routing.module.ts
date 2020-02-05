import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { HealthCheckComponent } from "./health-check/health-check.component";
import { SendEmailComponent } from "./send-email/send-email.component";

const routes: Routes = [
  { path: "", redirectTo: "send-email", pathMatch: "full" },
  { path: "health-check", component: HealthCheckComponent },
  { path: "send-email", component: SendEmailComponent }
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
