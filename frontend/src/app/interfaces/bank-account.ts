export default interface IBankAccount {
    accountNumber: string
    customerId: string;
    balance: number;
    minBalance: number;
    interestRate: number;
    createdAt: string;
    type: string;
    routingNumber: string;
}