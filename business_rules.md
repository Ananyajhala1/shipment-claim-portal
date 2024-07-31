# business_rules_shipmentClaim


### User Management:
- one can assign roles and create permissions provided he/she is in admin group.
- super company can create users, and can add users as super admin. 
### Customer Hierarchy
- only system customer can create corporate customers
- corporate customers can create sub customers 
- customer can add new insurance 
### claim settings 
- defined at system or corporate level 
### claim creation and editing
- users can create claims as a customer or 3PL.
- super admin is not allowed to create claims. \
- editing of claim is allowed to user who has created it.
- claim can't be edited after it is submitted finally.  
### Carrier rules 
- super admin can create
- customer can create 
- when one tries to check available carriers we should display carrier added by:
	- super admin 
	- customer itself
	- parent customer if it is there
### Insurance 
- super admin cannot create insurance company 
- only corporate customer can create insurance company
- they cannot edit or temper claim, they can update status of claim, or ask for some missing/necessary document(by assigning task to claimant). 
### miscellaneous
- corporate customer will not create claim, it will handle billing task. sub clients/sub corporate customers can create claim.
- validation of user should be done using JWT **only**. 
