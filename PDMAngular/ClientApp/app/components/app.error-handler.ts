import { ErrorHandler, Inject, NgZone } from "@angular/core";
import { ToastyService } from "ng2-toasty";

export class AppErrorHandler implements ErrorHandler {

    constructor( @Inject(NgZone) private ngZone: NgZone,
        @Inject(ToastyService) private tostyService: ToastyService) { }

    handleError(error: any): void {
        this.ngZone.run(() => {
            if (typeof (window) !== 'undefined') {
                this.tostyService.error({
                    title: 'Error',
                    msg: 'An unexpected error happend',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            }
        });


    }

}