import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
import { appRoutingModule } from './app.routing.module';

@NgModule({
    imports: [AppModule, ServerModule, ModuleMapLoaderModule, appRoutingModule],
    bootstrap: [AppComponent]
})
export class AppServerModule { }
