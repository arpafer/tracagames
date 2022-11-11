import { User } from './user';

describe('User', () => {
  it('should create an instance', () => {
    expect(new User("antonio", "antonio@gmail.com", true, "")).toBeTruthy();
  });
});
