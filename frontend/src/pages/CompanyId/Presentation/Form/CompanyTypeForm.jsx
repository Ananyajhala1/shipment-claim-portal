import React from 'react';

function CompanyTypeForm({ handleSubmit, companyType1, setCompanyType1 }) {
  return (
    <form onSubmit={handleSubmit}>
      <label>
        Company Type:
        <input
          type="text"
          value={companyType1}
          onChange={(e) => setCompanyType1(e.target.value)}
        />
      </label>
      <button type="submit">Submit</button>
    </form>
  );
}

export default CompanyTypeForm;
