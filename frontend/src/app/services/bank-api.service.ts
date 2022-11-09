import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import IBankAccount from "../interfaces/bank-account";
import IBeneficiary from "../interfaces/beneficiary";

@Injectable({
    providedIn: 'root'
})
export class BankApiService {

    private bankApiBaseUrl = "https://localhost:7241/api";

    constructor(private http: HttpClient) { }

    getBankAccount(accountNumber: string): Observable<IBankAccount> {
        return this.http.get<IBankAccount>(`${this.bankApiBaseUrl}/bankaccounts/${accountNumber}`);
    }

    getBeneficiariesOfAccount(accountNumber: string): Observable<IBeneficiary[]> {
        return this.http.get<IBeneficiary[]>(`${this.bankApiBaseUrl}/bankAccounts/${accountNumber}/beneficiaries`);
    }

}