export class Channel {
  id: string;
  name: string;
  tip: string;
  origine: string;

  constructor(input?: any) {
    Object.assign(this, input);
  }
}
