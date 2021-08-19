import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Contact } from '@app/_models';

const baseUrl = `/api/Contact`;

@Injectable({ providedIn: 'root' })
export class ContactService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<Contact[]>(baseUrl);
    }

    getById(id: string) {
        return this.http.get<Contact>(`${baseUrl}/${id}`);
    }

    create(params: any) {
        console.log(params);
        params['dateOfBirth'] = params['dateOfBirth'].replace(" 01:00:00", "") + " 01:00:00";
        return this.http.post(baseUrl, params);
    }

    update(id: string, params: any) {
        console.log(params);
        params['dateOfBirth'] = params['dateOfBirth'].replace(" 01:00:00", "") + " 01:00:00";
        return this.http.put(`${baseUrl}/${id}`, params);
    }

    delete(id: string) {
        return this.http.delete(`${baseUrl}/${id}`);
    }
}