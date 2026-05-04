---
kind: enumMember
id: F:Autodesk.Revit.Attributes.TransactionMode.Manual
enum: Autodesk.Revit.Attributes.TransactionMode
source: html/84254a1f-7bba-885a-ce65-e68fc238fddb.htm
---
# Autodesk.Revit.Attributes.TransactionMode.Manual

The API framework will not create a transaction (but will create an outer group to roll back all changes 
if the external command returns a failure status). Instead, you may use combinations of transactions, sub-transactions,
and groups. You will have to follow all rules regarding use of transactions and related classes.
You will have to give your transactions names, which will then appear in the undo menu.
Revit will check that all transactions (also groups and sub-transaction) are properly closed upon return from an external command.
If not, it will discard all changes to the model.

