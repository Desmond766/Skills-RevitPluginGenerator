---
kind: enumMember
id: F:Autodesk.Revit.Attributes.TransactionMode.ReadOnly
enum: Autodesk.Revit.Attributes.TransactionMode
source: html/84254a1f-7bba-885a-ce65-e68fc238fddb.htm
---
# Autodesk.Revit.Attributes.TransactionMode.ReadOnly

No transaction (nor group) will be created, and no transaction may be created for the lifetime of the command.
The External command may use methods that only read from the model, but not methods that write anything to it.
Exceptions will be thrown if the command either tries to start a transaction (or group) or attempts to write to the model.

