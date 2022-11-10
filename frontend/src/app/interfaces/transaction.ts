export default interface ITransaction {
    fromAccountNumber: string,
    toAccountNumber: string,
    amount: number,
    comment: string | undefined
}