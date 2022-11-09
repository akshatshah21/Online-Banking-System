import ITransaction from "./transaction";

export default interface IInitiatedTransaction extends ITransaction {
    transactionPin: string
}