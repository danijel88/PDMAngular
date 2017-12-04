import { KeyValuePair } from "./KeyValuePair";
import { Status } from "./status";

export interface Item {
    id: number;
    internalCode: string;
    description: string;
    band: number;
    enter: number;
    exit: number;
    thickness: number;
    elastic: boolean;
    madeBy: string;
    color: string;
    name: string;
    itemType: KeyValuePair;
    machineType: KeyValuePair;
    status: number;
}