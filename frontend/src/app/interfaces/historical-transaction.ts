import ITransaction from "./transaction";

export default interface IHistoricalTransaction extends ITransaction {
    id: string;
    timestamp: string;
}