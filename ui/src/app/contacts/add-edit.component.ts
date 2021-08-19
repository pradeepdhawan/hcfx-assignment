import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { formatDate } from '@angular/common';
import { ContactService, AlertService } from '@app/_services';
// import { DateValidator } from '@app/_helpers';
import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
    name: 'dateFormat',
})
export class DateFormat implements PipeTransform {
    transform(value: string) {
        var datePipe = new DatePipe("en-GB");
        return datePipe.transform(value, 'yyyy-MM-dd');
    }
}

@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form!: FormGroup;
    isAddMode!:boolean;
    contactId!: string;
    maxDate!: string;
    loading = false;
    submitted = false;
    dob!: Date;

    constructor(
        private datePipe: DatePipe,
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private contactService: ContactService,
        private alertService: AlertService
    ) {}

    ngOnInit() {
        this.contactId = this.route.snapshot.params['contactId'];
        //this.dateOfBirth = this.route.snapshot.params['dateOfBirth'];
        console.log(this.contactId);
        this.isAddMode = !this.contactId;
        this.maxDate = new Date().toJSON().split('T')[0];
        this.form = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            dateOfBirth:['', [Validators.required]]
        });
        if (!this.isAddMode) {
            this.contactService.getById(this.contactId)
                .pipe(first())
                .subscribe( x => { this.form.patchValue(x), console.log(x) });
        }
    }

    setDate(e: any){
        console.log(e.target.value);
    }
    parseDate(dateString: string): Date {
        if (dateString) {
            return new Date(dateString);
        }
        return new Date();
    }
    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;
        if (this.isAddMode) {
            this.createContact();
        } else {
            this.updateContact();
        }
    }

    private createContact() {
        this.contactService.create(this.form.value)
            .pipe(first())
            .subscribe(() => {
                this.alertService.success('Contact added', { keepAfterRouteChange: true });
                this.router.navigate(['../'], { relativeTo: this.route });
            })
            .add(() => this.loading = false);

    }

    private updateContact() {
        this.contactService.update(this.contactId, this.form.value)
            .pipe(first())
            .subscribe(() => {
                this.alertService.success('Contact updated', { keepAfterRouteChange: true });
                this.router.navigate(['../../'], { relativeTo: this.route });
            })
            .add(() => this.loading = false);

    }
}