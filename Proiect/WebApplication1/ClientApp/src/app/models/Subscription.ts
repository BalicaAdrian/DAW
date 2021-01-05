export class Subscription {
  id: string;
  name: string;
  price: number;
  period: number;
  channelId:string[];
  channels: string[];

  constructor(input?: any) {
    Object.assign(this, input);
  }
}
