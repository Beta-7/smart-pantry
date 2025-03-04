export type IOpenProduct = {
    productId?: string,
    name: string,
    remainingWeight: number,
    expirationDate: Date,
    openDate: Date,
    weight: number
    daysRemaining: number,
    isOpen?: boolean,
    id?: string,
    lastModified?: Date,
    created?: Date,
    deleted?: boolean,
}