# SamosaChai.NET-DemoFunction

Azure Function that rick rolls a person on phone call via Twilio

_Example input:_

This function expects a phone number in the body of the POST request in the following format: `+[Country Code][Phone Number]`

Here's an example JSON POST body:

```json
{
    "PhoneNumber": "+919876543210"
}
```

_Example output:_

```json
CA490dc7a73d82e12ac0083b3d5f9ec27e
```

This is the Call Sid generated

## 📝 Environment Variables

Go to Settings tab of your Cloud Function and add the following environment variables:

- `AccountSid`: Twilio Account SID
- `AuthToken`: Twilio Auth Token
- `FromNumber`: Twilio Phone Number to make the call from

> ℹ️ _The Twilio Account SID and Auth Token can be obtained from your Twilio console. You can purchase a Twilio phone number using [this guide](https://support.twilio.com/hc/en-us/articles/223135247-How-to-Search-for-and-Buy-a-Twilio-Phone-Number-from-Console)._
