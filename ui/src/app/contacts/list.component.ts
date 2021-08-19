import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { ContactService } from '@app/_services';
import { Contact } from '@app/_models';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
    contacts!: Contact[];

    constructor(private contactService: ContactService) {}

    ngOnInit() {
        this.contactService.getAll()
            .pipe(first())
            .subscribe(contacts => this.contacts = contacts);
    }

    deleteContact(contactId: string) {
        const contact = this.contacts.find(x => x.contactId === contactId);
        if (!contact) return;
        contact.isDeleting = true;
        this.contactService.delete(contactId)
            .pipe(first())
            .subscribe(() => this.contacts = this.contacts.filter(x => x.contactId !== contactId));
    }
}