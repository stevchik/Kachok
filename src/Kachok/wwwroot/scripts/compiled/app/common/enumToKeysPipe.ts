import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'enumToKeys' })
export class EnumToKeysPipe implements PipeTransform {
    transform(value: string[], args: string[]): any {
        let keys: EnumValue[] = new Array<EnumValue>();

        for (let enumMember of value) {
            let isValueProperty: boolean = parseInt(enumMember, 10) >= 0;

            if (isValueProperty) {
                keys.push(new EnumValue(enumMember, value[enumMember]));
            }
        }

        return keys;
    }
}

export class EnumValue {
    constructor(public key?: string, public value?: string) { };
}