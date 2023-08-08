// Form.js
import React, { useState } from 'react';

function Form() {
  const [formData, setFormData] = useState({
    mood: '',
    powerlevel: '',
  });

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    const response = await fetch('http://localhost:5000/api/kymanis', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(formData),
    });
  
    if (response.ok) {
      console.log('Kymani posted successfully');
    } else {
      console.error('Error submitting data');
    }
  };
  

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  return (
    <React.Fragment>
      <h2>Kymani form</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Mood:
          <input type="text" name="mood" value={formData.mood} onChange={handleInputChange} />
        </label>
        <br />
        <label>
          Powerlevel:
          <input type="number" name="powerlevel" value={formData.powerlevel} onChange={handleInputChange} />
        </label>
        <br />
        <button type="submit">Add kymani</button>
      </form>
    </React.Fragment>
  );
}

export default Form;
